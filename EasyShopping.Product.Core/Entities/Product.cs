using System.ComponentModel.DataAnnotations;

namespace EasyShopping.Product.Core.Entities
{
    public class Product: BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
