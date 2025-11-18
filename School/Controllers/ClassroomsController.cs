using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.BAL.Models.BAL;
using School.BAL.ClassroomsService.Queries.GetAllClassrooms;
using School.BAL.ClassroomsService.Queries.GetClassroomById;
using School.BAL.ClassroomsServicesService.Commands.CreateClassroom;
using School.BAL.ClassroomsServicesService.Commands.UpdateClassroom;
using School.BAL.ClassroomsServicesService.Commands.DeleteClassroom;
using School.BAL.ClassroomsServicesService.Commands.AddStudentToClass;
using School.BAL.ClassroomsServicesService.Commands.RemoveStudentFromClass;

[ApiController]
[Route("api/[controller]")]
public class ClassroomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassroomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<ClassroomDto>> GetAll()
    {
        return await _mediator.Send(new GetAllClassroomsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClassroomDto>> GetById(Guid id)
    {
        var classroom = await _mediator.Send(new GetClassroomByIdQuery(id));
        if (classroom == null) return NotFound();
        return Ok(classroom);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateClassroomDto dto)
    {
        var id = await _mediator.Send(new CreateClassroomCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CreateClassroomDto dto)
    {
        await _mediator.Send(new UpdateClassroomCommand(id, dto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteClassroomCommand(id));
        return NoContent();
    }

    [HttpPost("{classroomId}/students/{studentId}")]
    public async Task<IActionResult> AddStudent(Guid classroomId, Guid studentId)
    {
        await _mediator.Send(new AddStudentToClassCommand(classroomId, studentId));
        return NoContent();
    }

    [HttpDelete("{classroomId}/students/{studentId}")]
    public async Task<IActionResult> RemoveStudent(Guid classroomId, Guid studentId)
    {
        await _mediator.Send(new RemoveStudentFromClassCommand(classroomId, studentId));
        return NoContent();
    }
}
