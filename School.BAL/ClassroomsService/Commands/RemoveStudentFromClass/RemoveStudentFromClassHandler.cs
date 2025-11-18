using MediatR;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.RemoveStudentFromClass
{
    public class RemoveStudentFromClassHandler : IRequestHandler<RemoveStudentFromClassCommand, Unit>
    {
        private readonly ClassRepository _classRepo;
        private readonly StudentRepository _studentRepo;

        public RemoveStudentFromClassHandler(ClassRepository classRepo, StudentRepository studentRepo)
        {
            _classRepo = classRepo;
            _studentRepo = studentRepo;
        }

        public async Task<Unit> Handle(RemoveStudentFromClassCommand request, CancellationToken ct)
        {
            var student = await _studentRepo.GetByIdAsync(request.StudentId, ct)
                          ?? throw new InvalidOperationException("Student not found");

            await _classRepo.RemoveStudentAsync(request.ClassroomId, student, ct);
            return Unit.Value;
        }
    }
}
