using AutoMapper;
using MediatR;
using School.BAL.Models.BAL;
using School.DAL.Model;
using School.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BAL.Students.Queries.GetStudentById
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDto?>
    {
        private readonly StudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(StudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task<StudentDto?> Handle(GetStudentByIdQuery request, CancellationToken ct)
        {
            var student = await _studentRepo.GetByIdAsync(request.Id, ct);
            return _mapper.Map<StudentDto?>(student);
        }
    }
}
