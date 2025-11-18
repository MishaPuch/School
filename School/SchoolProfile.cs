using AutoMapper;
using School.BAL.Models.BAL;
using School.DAL.Model;

namespace School
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Classroom, ClassroomDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<CreateClassroomDto, Classroom>();
        }
    }
}
