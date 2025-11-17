using MediatR;
using StudentCQRSLab.Data;
using StudentCQRSLab.Models;

namespace StudentCQRSLab.Features.Queries
{
    public record GetStudentByIdQuery(int Id) : IRequest<Student?>; 
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student?>
    {
        private readonly StudentStore _store;
        public GetStudentByIdHandler(StudentStore store) => _store = store;

        public Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = _store.GetById(request.Id);
            return Task.FromResult(student);
        }
    }
}