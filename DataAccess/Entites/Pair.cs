using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Pair : BaseEntity
    {
        public string Name;
       
        public int? StudentId {  get; set; }
        public Student? Student { get; set; }

        public int? MentorId { get;set; }
        public Mentor? Mentor { get; set; }
    }
}
