using MediatR;
using School.DAL.Repositories;

namespace School.BAL.ClassroomsServicesService.Commands.DeleteClassroom
{
    public class DeleteClassroomHandler : IRequestHandler<DeleteClassroomCommand, Unit>
    {
        private readonly ClassRepository _classRepo;

        public DeleteClassroomHandler(ClassRepository classRepo)
        {
            _classRepo = classRepo;
        }

        public async Task<Unit> Handle(DeleteClassroomCommand request, CancellationToken ct)
        {
            var cls = await _classRepo.GetByIdAsync(request.Id, ct)
                      ?? throw new InvalidOperationException("Classroom not found");

            _classRepo.Remove(cls);
            await _classRepo.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
