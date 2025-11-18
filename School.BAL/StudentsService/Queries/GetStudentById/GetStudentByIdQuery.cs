using MediatR;
using School.BAL.Models.BAL;
using School.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Queries.GetStudentById
{
    public record GetStudentByIdQuery(Guid Id) : IRequest<StudentDto?>;
}
