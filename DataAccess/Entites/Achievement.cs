using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Achievement : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        [Range(10, 1000)]
        public required ulong XP { get; set; }
    }
}
