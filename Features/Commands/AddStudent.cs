using MediatR;
using StudentCQRSLab.Data;
using StudentCQRSLab.Models;

namespace StudentCQRSLab.Features.Commands
{
    public record AddStudentCommand(string Name, string Email, int Age) : IRequest<Student>;

    
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly StudentStore _store;
        public AddStudentHandler(StudentStore store) => _store = store;

        public Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var newStudent = new Student
            {
                Name = request.Name,
                Email = request.Email,
                Age = request.Age
            };
            _store.Add(newStudent);
            return Task.FromResult(newStudent);
        }
    }
}