using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Core.Model
{
    public class Studentmodel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentDOB { get; set; }

        public string StudentGender { get; set; }

        public string StudentCourse { get; set; }

        public string StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public string StudentAddress { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsEnglish { get; set; }

        public bool IsMathmatics { get; set; }

        public bool IsPhysics { get; set; }

        public bool IsChemistry { get; set; }

        public bool IsBiology { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public DateTime UpdateTimeStamp { get; set; }
        public int UserId {  get; set; }
    }
}