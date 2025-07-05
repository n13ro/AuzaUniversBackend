using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, PaginationResponse<StudentRequest>>
    {
        private readonly IRepository<Student> _studentRepository;

        public GetStudentsQueryHandler(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<PaginationResponse<StudentRequest>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            
            var students = await _studentRepository.GetAllAsync(request.Page, request.PageSize);

            return new PaginationResponse<StudentRequest>
            {
                Items = students.Select(s => new StudentRequest
                {
                    Id = s.Id,
                    Name = s.Name,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Phone = s.Phone,
                    Level = s.Level
                }),
                Page = request.Page,
                PageSize = request.PageSize,
            };


        }
    }
}
