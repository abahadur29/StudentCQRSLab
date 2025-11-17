using MediatR;
using StudentCQRSLab.Data;
using StudentCQRSLab.Models;

namespace StudentCQRSLab.Features.Queries
{
    public record GetAllStudentsQuery() : IRequest<List<Student>>;
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly StudentStore _store;
        public GetAllStudentsHandler(StudentStore store) => _store = store;

        public Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = _store.GetAll();
            return Task.FromResult(students);
        }
    }
}