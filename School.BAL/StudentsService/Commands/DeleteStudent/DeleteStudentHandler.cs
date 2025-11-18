using MediatR;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Commands.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly StudentRepository _studentRepo;

        public DeleteStudentHandler(StudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken ct)
        {
            var student = await _studentRepo.GetByIdAsync(request.Id, ct)
                          ?? throw new InvalidOperationException("Student not found");

            _studentRepo.Remove(student);
            await _studentRepo.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
