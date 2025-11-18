using MediatR;
using School.BAL.Models.BAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Queries.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<StudentDto>>;
}
