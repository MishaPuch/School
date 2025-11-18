using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.DeleteClassroom
{
    public record DeleteClassroomCommand(Guid Id) : IRequest<Unit>;
}
