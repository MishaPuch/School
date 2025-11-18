using AutoMapper;
using MediatR;
using School.BAL.Models.BAL;
using School.DAL.Repositories;

namespace School.BAL.ClassroomsService.Queries.GetAllClassrooms
{
    public class GetAllClassroomsHandler : IRequestHandler<GetAllClassroomsQuery, IEnumerable<ClassroomDto>>
    {
        private readonly ClassRepository _classRepo;
        private readonly IMapper _mapper;

        public GetAllClassroomsHandler(ClassRepository classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassroomDto>> Handle(GetAllClassroomsQuery request, CancellationToken ct)
        {
            var classrooms = await _classRepo.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<ClassroomDto>>(classrooms);
        }
    }
}
