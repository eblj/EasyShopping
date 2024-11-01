using System.ComponentModel.DataAnnotations;

namespace EasyShopping.Product.Core.Entities
{
    public class Category: BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
