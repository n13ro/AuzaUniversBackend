using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.DTOPair
{
    public class DTOPairRepository
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required DateTime DateTime { get; set; }

        [Required]
        public required int Auditorium { get; set; }
    }
}
