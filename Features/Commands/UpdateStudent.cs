using MediatR;
using StudentCQRSLab.Data;
using StudentCQRSLab.Models;

namespace StudentCQRSLab.Features.Commands
{
    public record UpdateStudentCommand(int Id, string Name, string Email, int Age) : IRequest<bool>;
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly StudentStore _store;
        public UpdateStudentHandler(StudentStore store) => _store = store;

        public Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToUpdate = new Student
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Age = request.Age
            };

            _store.Update(studentToUpdate);

            
            return Task.FromResult(true);
        }
    }
}