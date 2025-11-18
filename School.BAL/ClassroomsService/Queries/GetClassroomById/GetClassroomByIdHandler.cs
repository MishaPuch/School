using AutoMapper;
using MediatR;
using School.BAL.Models.BAL;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsService.Queries.GetClassroomById
{
    public class GetClassroomByIdHandler : IRequestHandler<GetClassroomByIdQuery, ClassroomDto?>
    {
        private readonly ClassRepository _classRepo;
        private readonly IMapper _mapper;

        public GetClassroomByIdHandler(ClassRepository classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }

        public async Task<ClassroomDto?> Handle(GetClassroomByIdQuery request, CancellationToken ct)
        {
            var classroom = await _classRepo.GetByIdAsync(request.Id, ct);
            return _mapper.Map<ClassroomDto?>(classroom);
        }
    }
}
