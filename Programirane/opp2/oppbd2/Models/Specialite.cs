using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace oppbd2.Models
{
    public partial class Specialite
    {
        public Specialite()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string GraduatesTitle { get; set; } = null!;
        public int StartGrade { get; set; }
        public int EndGrade { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public string specialityinfo()
        {
            string specialitylInfo = $"Id:{Id} {Name}";

            return specialitylInfo;
        }
    }
}
