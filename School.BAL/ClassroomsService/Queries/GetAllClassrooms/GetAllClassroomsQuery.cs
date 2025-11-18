using MediatR;
using School.BAL.Models.BAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsService.Queries.GetAllClassrooms
{
    public record GetAllClassroomsQuery() : IRequest<IEnumerable<ClassroomDto>>;
}
