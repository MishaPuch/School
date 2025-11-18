using AutoMapper;
using MediatR;
using School.DAL.Model;
using School.DAL.Repositories;

namespace School.BAL.ClassroomsServicesService.Commands.CreateClassroom
{
    public class CreateClassroomHandler : IRequestHandler<CreateClassroomCommand, Guid>
    {
        private readonly ClassRepository _classRepo;
        private readonly IMapper _mapper;

        public CreateClassroomHandler(ClassRepository classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateClassroomCommand request, CancellationToken ct)
        {
            var cls = _mapper.Map<Classroom>(request.Classroom);
            return await _classRepo.AddAsync(cls, ct);
        }
    }
}
