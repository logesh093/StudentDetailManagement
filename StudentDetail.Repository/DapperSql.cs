using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail.Repository
{
    public class DapperSql
    {
        public const String InsertData = "Insert into StudentDetails_Table(Student_Name,Student_DOB,Student_Gender,Student_Course,Student_ContactNumber,Student_Email,Student_Address,Is_English,Is_Mathmatics,Is_Physics,Is_Chemistry,Is_Biology,Create_Time_Stamp,Update_Time_Stamp,User_Id) VALUES(@name,@dob,@gender,@course,@phonenumber,@emailid,@address,@isenglish,@ismathmatics,@isphysics,@ischemistry,@isbiology,@createdtimestamp,@updatedtimestamp,@userid)";
        public const String StudentDetailUpdate = "Update StudentDetails_Table Set Student_Name=@name,Student_DOB=@dob,Student_Gender=@gender,Student_Course=@course,Student_ContactNumber=@phonenumber,Student_Email=@emailid,Student_Address=@address,Is_English=@isenglish,Is_Mathmatics=@ismathmatics,Is_Physics=@isphysics,Is_Chemistry=@ischemistry,Is_Biology=@isbiology,Update_Time_Stamp=@updatedtimestamp  where Student_Id=@id";
        public static String SignupDetail = "Insert into User_SignUp(User_Name,User_Phonenumber,User_Emailid,Hash_Password,Salt_Password) VALUES(@name,@phonenumber,@emailid,@hashpassword,@saltpassword)";
        public const String CheckDetail = "Select User_Emailid as UserEmailid, Hash_Password as HashPassword from User_SignUp where User_Emailid=@emailid ";
        public const String LoginDetail = "Select Hash_Password as HashPassword,Salt_Password as SaltPassword from User_SignUp where User_Emailid=@emailid ";
        public const String DisplayData = "select Student_Id as StudentId,Student_Name as StudentName,Student_DOB as StudentDOB,Student_Gender as StudentGender,Student_Course as StudentCourse,Student_ContactNumber as StudentContactNumber,Student_Email as StudentEmail,Student_Address as StudentAddress,Is_English as IsEnglish,Is_Mathmatics as IsMathmatics,Is_Physics as IsPhysics,Is_Chemistry as IsChemistry,Is_Biology as IsBiology From StudentDetails_Table  where Is_Deleted=0 and User_Id=@userid ORDER BY Update_Time_Stamp DESC";
        public const String DeleteDetail = "Update StudentDetails_Table Set Is_Deleted=@del where Student_Id=@Stdid";
        public const String GetDataById = "select Student_Id as StudentId,Student_Name as StudentName,Student_DOB as StudentDOB,Student_Gender as StudentGender,Student_Course as StudentCourse,Student_ContactNumber as StudentContactNumber,Student_Email as StudentEmail,Student_Address as StudentAddress,Is_English as IsEnglish,Is_Mathmatics as IsMathmatics,Is_Physics as IsPhysics,Is_Chemistry as IsChemistry,Is_Biology as IsBiology from StudentDetails_Table where Student_Id=@id and Is_Deleted=0";
        public const String GetUserDetail = "select User_Id as UserId from User_SignUp where User_Emailid=@emailid";



    }
}
