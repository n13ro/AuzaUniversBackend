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
        private readonly IRepository<Group> _groupRepository;
        public CreateStudentCommandHandler(IRepository<Student> studentRepository, IRepository<Group> groupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetByIdAsync(request.GroupId);
            if (group == null)
            {
                throw new Exception("Группа не найдена");
            }

            var student = new Student(
                request.Name,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Phone,
                request.Level
            );

            student.EnrollInGroup(group);

            var createdStudent = await _studentRepository.AddAsync(student);
            return createdStudent.Id;
        }
    }
}
