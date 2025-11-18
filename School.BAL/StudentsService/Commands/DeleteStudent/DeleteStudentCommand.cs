using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Commands.DeleteStudent
{
    public record DeleteStudentCommand(Guid Id) : IRequest<Unit>;
}
