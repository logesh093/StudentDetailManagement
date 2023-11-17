using Dapper;
using Entity.Models;
using Microsoft.Azure.Documents;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentData.Core.IRepository;
using StudentData.Core.Model;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentDetail.Repository
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _configure;
        public IDbConnection Connection => new SqlConnection(_configure.GetConnectionString("DefaultConnection"));
        public Repository(IConfiguration configure)
        {
            _configure = configure;
        }

        #region StudentLogin
        public int StudentLogin(StudentLogin studentlogin)
        {
           

            if (studentlogin != null)
            {
                using (var connections = Connection)
                {                   
                    UserPassword passworddetail = connections.Query<UserPassword>(DapperSql.LoginDetail, new { @emailid = studentlogin.StudentEmailid }).SingleOrDefault();
                    if (passworddetail != null)
                    {
                        bool result = VerifyPassword(studentlogin.StudentPassword, passworddetail.HashPassword, passworddetail.SaltPassword);
                        if(result)
                        {
                            int userId = connections.Query<int>(DapperSql.GetUserDetail, new { @emailid = studentlogin.StudentEmailid }).SingleOrDefault();

                            return userId;
                        }
                        else
                        {
                            int userId = 0;
                            return userId;
                        }
                       
                       
                    }
                    
                }
                   
            }
            return 0;
        }
        #endregion

        #region Addsignup details
        public bool AddSignUpDetails(UserDetail details)
        {
            UserPassword obj=new UserPassword();
            if(details != null)
            {
                using (var connections = Connection)
                {
                    var signupdetail = (connections.Query<UserDetail>(DapperSql.CheckDetail, new
                    {
                        @emailid = details.UserEmailid

                    })).SingleOrDefault();

                    if (signupdetail == null)
                    {
                        const int keySize = 64;
                        const int iterations = 350000;
                        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

                        obj.SaltPassword = RandomNumberGenerator.GetBytes(keySize);

                        var hash = Rfc2898DeriveBytes.Pbkdf2(
                            Encoding.UTF8.GetBytes(details.Password),
                           obj.SaltPassword,
                            iterations,
                            hashAlgorithm,
                            keySize);

                        obj.HashPassword = Convert.ToHexString(hash);

                        connections.Execute(DapperSql.SignupDetail,
                      new
                      {
                          @name = details.UserName,
                          @phonenumber = details.Phonenumber,
                          @emailid = details.UserEmailid,
                          @hashpassword = obj.HashPassword,
                          @saltpassword= obj.SaltPassword,
                      });
                        return true;
                    }

                  
                }

                
            }


            return false;
        }
        #endregion

        #region Create and Update details
        public bool SaveandUpdateStudentDetails(Studentmodel studentdetail)
        {

            if (studentdetail.StudentId > 0)
            {

                using (var connections = Connection)
                {
                    var a = connections.Execute(DapperSql.StudentDetailUpdate,
                    new
                    {
                        @id = studentdetail.StudentId,
                        @name = studentdetail.StudentName,
                        @dob = studentdetail.StudentDOB,
                        @gender = studentdetail.StudentGender,
                        @course = studentdetail.StudentCourse,
                        @phonenumber = studentdetail.StudentContactNumber,
                        @emailid = studentdetail.StudentEmail,
                        @address = studentdetail.StudentAddress,
                        @isenglish = studentdetail.IsEnglish,
                        @ismathmatics = studentdetail.IsMathmatics,
                        @isphysics = studentdetail.IsPhysics,
                        @ischemistry = studentdetail.IsChemistry,
                        @isbiology = studentdetail.IsBiology,
                        @updatedtimestamp = DateTime.Now
                        
                    });
                }

                return false;

            }
            else
            {
                using (var connections = Connection)
                {
                    var a = connections.Execute(DapperSql.InsertData,
                    new
                    {
                        //@id = studentmodel.StudentId,
                        @name = studentdetail.StudentName,
                        @dob = studentdetail.StudentDOB,
                        @gender = studentdetail.StudentGender,
                        @course = studentdetail.StudentCourse,
                        @phonenumber = studentdetail.StudentContactNumber,
                        @emailid = studentdetail.StudentEmail,
                        @address = studentdetail.StudentAddress,
                        @isenglish = studentdetail.IsEnglish,
                        @ismathmatics = studentdetail.IsMathmatics,
                        @isphysics = studentdetail.IsPhysics,
                        @ischemistry = studentdetail.IsChemistry,
                        @isbiology = studentdetail.IsBiology,
                        @createdtimestamp = DateTime.Now,
                        @updatedtimestamp = DateTime.Now,
                        @userid = studentdetail.UserId
                    });
                }
                return true;
            }
        }
        #endregion

        #region Student dashboard
        public List<Studentmodel> StudentDashBoard(int id)
        {

            using (var connections = Connection)
            {
                var studentlist = (connections.Query<Studentmodel>(DapperSql.DisplayData,
                    new
                    {
                        @userid = id,
                    })).ToList();

                return studentlist;
            }
                
        }
        #endregion

        #region Delete Student detail by Id
        public bool Delete(int studentid)
        {
            using (var connections = Connection)
            {
                var a = connections.Query(DapperSql.DeleteDetail,
                new
                {
                    @Stdid = studentid,
                    @del = true

                }).SingleOrDefault();
                return true;
            }
                
        }
        #endregion

        #region Get Data By Id
        public Studentmodel GetStudentdetail(int studentid)
        {

            using (var connections = Connection)
            {
                var studentlist = (connections.Query<Studentmodel>(DapperSql.GetDataById,
                new
                {
                    @id = studentid,
                })).SingleOrDefault();
                return studentlist;
            }
                
        }
        #endregion
        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            const int keySize = 64;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

    }


}
