using System;
using System.Collections.Generic;

namespace oppbd2.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public int Grade { get; set; }
        public string GradeLetter { get; set; } = null!;
        public int SpecialityId { get; set; }

        public virtual Specialite Speciality { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public string  Info()
        {
            string ClasslInfo = $"--{Grade}{GradeLetter} ";
           
            return ClasslInfo;
        }
    }
}
