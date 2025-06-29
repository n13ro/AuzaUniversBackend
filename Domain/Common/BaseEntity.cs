using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }


        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        protected void SetUpdate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
