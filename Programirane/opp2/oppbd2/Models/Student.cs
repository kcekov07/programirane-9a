using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;


namespace oppbd2.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gsm { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;

        public string GetInfo()
        {
            string personalInfo = $"Id:{Id}\n{FirstName[0]}.{SurName} {LastName}";
            string accountData = "";
            string classinfo = Class.Info();
            

            return personalInfo+ classinfo;
        }

    }


}
