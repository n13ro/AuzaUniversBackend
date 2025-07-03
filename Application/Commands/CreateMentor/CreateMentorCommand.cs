using Domain.Entities;
using MediatR;


namespace Application.Commands.CreateMentor
{
    public class CreateMentorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
