using MediatR;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.ClassroomsServicesService.Commands.AddStudentToClass
{
    public class AddStudentToClassHandler : IRequestHandler<AddStudentToClassCommand, Unit>
    {
        private readonly ClassRepository _classRepo;
        private readonly StudentRepository _studentRepo;

        public AddStudentToClassHandler(ClassRepository classRepo, StudentRepository studentRepo)
        {
            _classRepo = classRepo;
            _studentRepo = studentRepo;
        }

        public async Task<Unit> Handle(AddStudentToClassCommand request, CancellationToken ct)
        {
            var student = await _studentRepo.GetByIdAsync(request.StudentId, ct)
                          ?? throw new InvalidOperationException("Student not found");

            await _classRepo.AddStudentAsync(request.ClassroomId, student, ct);
            return Unit.Value;
        }
    }
}
