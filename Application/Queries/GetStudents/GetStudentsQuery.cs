using Application.DTOs;
using MediatR;


namespace Application.Queries.GetStudents
{
    public record GetStudentsQuery : IRequest<IEnumerable<StudentRequest>>
    {
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 20;
    }
}
