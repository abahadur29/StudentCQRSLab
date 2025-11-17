using MediatR;
using StudentCQRSLab.Data;

namespace StudentCQRSLab.Features.Commands
{
    
    public record DeleteStudentCommand(int Id) : IRequest<bool>;

    
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly StudentStore _store;
        public DeleteStudentHandler(StudentStore store) => _store = store;

        public Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            bool success = _store.Delete(request.Id);
            return Task.FromResult(success);
        }
    }
}