using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.RemoveStudentFromClass
{
    public record RemoveStudentFromClassCommand(Guid ClassroomId, Guid StudentId) : IRequest<Unit>;
}
