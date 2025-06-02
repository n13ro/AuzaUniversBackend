
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entites
{
        public abstract class BaseEntity
        {
            [Key]
            public int Id { get; set; }

        }
}
