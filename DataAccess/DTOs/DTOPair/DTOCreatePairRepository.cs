
using System.ComponentModel.DataAnnotations;


namespace DataAccess.DTOs.DTOPair
{
    public class DTOCreatePairRepository
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
