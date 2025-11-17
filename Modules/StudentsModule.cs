using Carter;
using MediatR;
using StudentCQRSLab.Features.Commands;
using StudentCQRSLab.Features.Queries;
using StudentCQRSLab.Models;

namespace StudentCQRSLab.Modules
{
    public class StudentsModule : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
           
            app.MapGet("/students", async (ISender sender) =>
            {
               
                var students = await sender.Send(new GetAllStudentsQuery());
                return Results.Ok(students);
            });

            app.MapGet("/students/{id:int}", async (ISender sender, int id) =>
            {
               
                var student = await sender.Send(new GetStudentByIdQuery(id));
                return student is null ? Results.NotFound() : Results.Ok(student);
            });

            app.MapPost("/students", async (ISender sender, Student student) =>
            {
                
                var newStudent = await sender.Send(
                    new AddStudentCommand(student.Name, student.Email, student.Age));

                return Results.Created($"/students/{newStudent.Id}", newStudent);
            });

            app.MapPut("/students/{id:int}", async (ISender sender, int id, Student student) =>
            {
                
                await sender.Send(
                    new UpdateStudentCommand(id, student.Name, student.Email, student.Age));

                return Results.NoContent(); 
            });

            app.MapDelete("/students/{id:int}", async (ISender sender, int id) =>
            {
                
                bool success = await sender.Send(new DeleteStudentCommand(id));

                return success ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}