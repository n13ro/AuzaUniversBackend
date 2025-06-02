

namespace DataAccess.Entites
{
    public class Mentor : BaseEntity
    {
        public required string Name { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        //public HashSet<Group> Groups { get; set; } = new();
        public HashSet<Pair> Pairs { get; set; } = new();
    }
}
