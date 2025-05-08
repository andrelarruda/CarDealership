using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
