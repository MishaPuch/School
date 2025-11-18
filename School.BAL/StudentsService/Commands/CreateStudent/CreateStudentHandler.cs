using AutoMapper;
using MediatR;
using School.DAL;
using School.DAL.Model;
using School.DAL.Repositories;

namespace School.BAL.Students.Commands.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
		private readonly StudentRepository _studentRepo;
		private readonly IMapper _mapper;

		public CreateStudentHandler(StudentRepository studentRepo, IMapper mapper)
		{
			_studentRepo = studentRepo;
			_mapper = mapper;
		}

		public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken ct)
		{
			var student = _mapper.Map<Student>(request.Student);
			return await _studentRepo.AddAsync(student, ct);
		}
	}
}
