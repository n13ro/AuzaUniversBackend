using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IRepository<Student> _studentRepository;

        public CreateStudentCommandHandler(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(
                request.Name,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Phone,
                request.Level
            );

            var createdStudent = await _studentRepository.AddAsync(student);
            return createdStudent.Id;
        }
    }
}
