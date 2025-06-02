
using System.ComponentModel.DataAnnotations;


namespace DataAccess.DTOs.Ment
{
    public class DTOCreateMentorRepository
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
