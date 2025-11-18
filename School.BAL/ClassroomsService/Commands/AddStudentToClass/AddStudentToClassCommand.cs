using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.AddStudentToClass
{
    public record AddStudentToClassCommand(Guid ClassroomId, Guid StudentId) : IRequest<Unit>;
}
