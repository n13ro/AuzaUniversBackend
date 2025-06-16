using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Coins : BaseEntity
    {
        [Range(1, 100)]
        public decimal Amount { get; set; }
        public HashSet<Student> Students { get; set; } = new();

    }
}
