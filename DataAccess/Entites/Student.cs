using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int? MyPairId { get; set; }
        public Pair? MyPair { get; set; }

        public int? MyGroupId { get; set; }
        public Group? MyGroup { get; set; }

    }
}
