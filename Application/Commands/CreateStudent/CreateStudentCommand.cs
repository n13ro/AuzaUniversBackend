using Domain.Entities;
using Domain.Interfaces;
using MediatR;


namespace Application.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public int GroupId { get; set; }
    }
}
