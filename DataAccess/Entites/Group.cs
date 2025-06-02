

namespace DataAccess.Entites
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public HashSet<Student> StudentsGroup { get; set; } = new();
        public HashSet<Pair> Pairs { get; set; } = new();
        public HashSet<Mentor> Mentors { get; set; } = new();

    }
}
