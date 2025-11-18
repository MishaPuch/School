using AutoMapper;
using MediatR;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Commands.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly StudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public UpdateStudentHandler(StudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken ct)
        {
            var student = await _studentRepo.GetByIdAsync(request.Id, ct)
                          ?? throw new InvalidOperationException("Student not found");

            _mapper.Map(request.Student, student);
            _studentRepo.Update(student);
            await _studentRepo.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
