using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentRequest>>
    {
        private readonly IRepository<Student> _studentRepository;

        public GetStudentsQueryHandler(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentRequest>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllAsync();

            return students.Select(s => new StudentRequest
            {
                Id = s.Id,
                Name = s.Name,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Phone = s.Phone,
                Level = s.Level
            });
        }
    }
}
