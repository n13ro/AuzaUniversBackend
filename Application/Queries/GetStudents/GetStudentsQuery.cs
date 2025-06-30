using Application.DTOs;
using MediatR;


namespace Application.Queries.GetStudents
{
    public record GetStudentsQuery : IRequest<IEnumerable<StudentDto>> { }
}
