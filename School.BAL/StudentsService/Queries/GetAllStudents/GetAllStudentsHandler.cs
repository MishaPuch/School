using AutoMapper;
using MediatR;
using School.BAL.Models.BAL;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Queries.GetAllStudents
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly StudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public GetAllStudentsHandler(StudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken ct)
        {
            var students = await _studentRepo.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
