

namespace DataAccess.Entites
{
    public class Student : BaseEntity
    {
        public required string Name { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public HashSet<Pair> MyPairs { get; set; } = new();

        public HashSet<Coins> Coins { get; set; } = new();

        //public int? MyGroupId { get; set; }
        //public Group? MyGroup { get; set; }

    }
}
