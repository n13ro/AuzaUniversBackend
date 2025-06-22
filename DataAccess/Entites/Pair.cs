

namespace DataAccess.Entites
{
    public class Pair : BaseEntity
    {
        public required string Name { get; set; }
       
        public required DateTime DateTime { get; set; }

        public required int Auditorium { get; set; }

        public ICollection<Student>? Students { get; set; }

        public ICollection<Mentor>? Mentors { get; set; }
    }
}
