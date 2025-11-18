using MediatR;
using School.BAL.Models.BAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Commands.UpdateStudent
{
    public record UpdateStudentCommand(Guid Id, CreateStudentDto Student) : IRequest<Unit>;
}
