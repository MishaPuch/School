using MediatR;
using School.BAL.Models.BAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServices.Commands.CreateClassroom
{
    public record CreateClassroomCommand(CreateClassroomDto Classroom) : IRequest<Guid>;
}
