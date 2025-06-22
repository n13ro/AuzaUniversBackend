

namespace DataAccess.Entites
{
    public class Mentor : BaseEntity
    {
        public required string Name { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public ICollection<Group>? Groups { get; set; }
        public ICollection<Pair>? MyPairs { get; set; }
    }
}
