using MediatR;
using School.BAL.Models.BAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.UpdateClassroom
{
    public record UpdateClassroomCommand(Guid Id, CreateClassroomDto Classroom) : IRequest<Unit>;
}
