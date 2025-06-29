using Application.DTOs;
using MediatR;


namespace Application.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
    }
}
