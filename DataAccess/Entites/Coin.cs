using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Coin : BaseEntity
    {
        [Range(1, 100)]
        public decimal Amount { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
