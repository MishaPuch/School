using MediatR;
using School.BAL.Models.BAL;
using School.DAL.Model;

namespace School.BAL.Students.Commands.CreateStudent
{
    public record CreateStudentCommand(CreateStudentDto Student) : IRequest<Guid>;
}
