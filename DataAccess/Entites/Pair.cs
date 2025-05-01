using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Pair : BaseEntity
    {
        public string? Name { get; set; }
       
        public DateTime DateTime { get; set; }

        public int Auditorium { get; set; }

        public HashSet<Student> Students { get; set; } = new();

        public int? GroupId { get; set; }
        public Group? GroupPair { get; set; }

        public int? MentorId { get;set; }
        public Mentor? Mentor { get; set; }
    }
}
