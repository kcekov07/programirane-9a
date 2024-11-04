using System;
using System.Collections.Generic;

namespace oppbd2.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Gender { get; set; }
        public string Email { get; set; } = null!;
        public string? Subjects { get; set; }
        public int? ManagedClassId { get; set; }

        public virtual Class? ManagedClass { get; set; }
    }
}
