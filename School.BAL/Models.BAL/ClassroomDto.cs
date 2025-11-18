using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Models.BAL
{
    public class ClassroomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        public List<StudentDto> Students { get; set; } = new();
    }
}
