

using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entites
{
    public class Student : BaseEntity
    {
        public required string Name { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        [Range(1, 100)]
        public int Level { get; set; } = 1;

        public ICollection<Pair>? MyPairs { get; set; }

        public ICollection<Coin>? Coins { get; set; }

        public int MyGroupId { get; set; }
        public Group? MyGroup { get; set; }

    }
}
