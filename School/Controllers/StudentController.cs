using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.BAL.Models.BAL;
using School.BAL.Students.Queries.GetAllStudents;
using School.BAL.Students.Queries.GetStudentById;
using School.BAL.Students.Commands.CreateStudent;
using School.BAL.Students.Commands.UpdateStudent;
using School.BAL.Students.Commands.DeleteStudent;

//[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<StudentDto>> GetAll()
    {
        return await _mediator.Send(new GetAllStudentsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetById(Guid id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateStudentDto dto)
    {
        var id = await _mediator.Send(new CreateStudentCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CreateStudentDto dto)
    {
        await _mediator.Send(new UpdateStudentCommand(id, dto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteStudentCommand(id));
        return NoContent();
    }
}
