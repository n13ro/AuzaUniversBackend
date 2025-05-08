using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.DTOPair
{
    public class DTOPairRepository : Pair
    {
        public string? Name { get; set; }

        public DateTime DateTime { get; set; }

        public int Auditorium { get; set; }
    }
}
