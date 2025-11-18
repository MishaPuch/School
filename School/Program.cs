using Microsoft.EntityFrameworkCore;
using School.DAL;
using School.DAL.Repositories;
using MediatR;
using School.BAL.Models.BAL;
using School.BAL.Students.Queries.GetAllStudents;
using School.BAL.Students.Queries.GetStudentById;
using School.BAL.Students.Commands.CreateStudent;
using School.BAL.Students.Commands.UpdateStudent;
using School.BAL.Students.Commands.DeleteStudent;
using School.BAL.ClassroomsService.Queries.GetAllClassrooms;
using School.BAL.ClassroomsService.Queries.GetClassroomById;
using School.BAL.ClassroomsServices.Commands.CreateClassroom;
using School.BAL.ClassroomsServices.Commands.UpdateClassroom;
using School.BAL.ClassroomsServices.Commands.DeleteClassroom;
using School.BAL.ClassroomsServices.Commands.AddStudentToClass;
using School.BAL.ClassroomsServices.Commands.RemoveStudentFromClass;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Data");

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<ClassRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1");
    c.RoutePrefix = "";
});

app.UseHttpsRedirection();

var students = app.MapGroup("/api/students");

students.MapGet("/", async (IMediator mediator) =>
    await mediator.Send(new GetAllStudentsQuery()));

students.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
{
    var student = await mediator.Send(new GetStudentByIdQuery(id));
    return student is not null ? Results.Ok(student) : Results.NotFound();
});

students.MapPost("/", async (CreateStudentDto dto, IMediator mediator) =>
{
    var id = await mediator.Send(new CreateStudentCommand(dto));
    return Results.Created($"/api/students/{id}", id);
});

students.MapPut("/{id:guid}", async (Guid id, CreateStudentDto dto, IMediator mediator) =>
{
    await mediator.Send(new UpdateStudentCommand(id, dto));
    return Results.NoContent();
});

students.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
{
    await mediator.Send(new DeleteStudentCommand(id));
    return Results.NoContent();
});

var classrooms = app.MapGroup("/api/classrooms");

classrooms.MapGet("/", async (IMediator mediator) =>
    await mediator.Send(new GetAllClassroomsQuery()));

classrooms.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
{
    var classroom = await mediator.Send(new GetClassroomByIdQuery(id));
    return classroom is not null ? Results.Ok(classroom) : Results.NotFound();
});

classrooms.MapPost("/", async (CreateClassroomDto dto, IMediator mediator) =>
{
    var id = await mediator.Send(new CreateClassroomCommand(dto));
    return Results.Created($"/api/classrooms/{id}", id);
});

classrooms.MapPut("/{id:guid}", async (Guid id, CreateClassroomDto dto, IMediator mediator) =>
{
    await mediator.Send(new UpdateClassroomCommand(id, dto));
    return Results.NoContent();
});

classrooms.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
{
    await mediator.Send(new DeleteClassroomCommand(id));
    return Results.NoContent();
});

classrooms.MapPost("/{classroomId:guid}/students/{studentId:guid}", async (Guid classroomId, Guid studentId, IMediator mediator) =>
{
    await mediator.Send(new AddStudentToClassCommand(classroomId, studentId));
    return Results.NoContent();
});

classrooms.MapDelete("/{classroomId:guid}/students/{studentId:guid}", async (Guid classroomId, Guid studentId, IMediator mediator) =>
{
    await mediator.Send(new RemoveStudentFromClassCommand(classroomId, studentId));
    return Results.NoContent();
});

app.Run();
