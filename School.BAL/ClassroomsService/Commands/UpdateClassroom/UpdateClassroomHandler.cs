using AutoMapper;
using MediatR;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.UpdateClassroom
{
    public class UpdateClassroomHandler : IRequestHandler<UpdateClassroomCommand, Unit>
    {
        private readonly ClassRepository _classRepo;
        private readonly IMapper _mapper;

        public UpdateClassroomHandler(ClassRepository classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateClassroomCommand request, CancellationToken ct)
        {
            var cls = await _classRepo.GetByIdAsync(request.Id, ct)
                      ?? throw new InvalidOperationException("Classroom not found");

            _mapper.Map(request.Classroom, cls);
            _classRepo.Update(cls);
            await _classRepo.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
