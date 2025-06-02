

namespace DataAccess.Entites
{
    public class Pair : BaseEntity
    {
        public required string Name { get; set; }
       
        public required DateTime DateTime { get; set; }

        public required int Auditorium { get; set; }

        public HashSet<Student> Students { get; set; } = new();

        //public int? GroupId { get; set; }
        //public Group? GroupPair { get; set; }

        public int? MentorId { get;set; }
        public Mentor? Mentor { get; set; }
    }
}
