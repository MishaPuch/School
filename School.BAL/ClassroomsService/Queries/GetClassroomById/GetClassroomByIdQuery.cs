using MediatR;
using School.BAL.Models.BAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsService.Queries.GetClassroomById
{
    public record GetClassroomByIdQuery(Guid Id) : IRequest<ClassroomDto?>;
}
