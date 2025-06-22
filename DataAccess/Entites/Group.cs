

namespace DataAccess.Entites
{
    public class Group : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Mentor> Mentors { get; set; } = new List<Mentor>();

    }
}
