using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Models.BAL
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string StudentIdentifier { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public Guid? ClassroomId { get; set; }
    }
}
