using System.ComponentModel.DataAnnotations;

namespace EasyShopping.Cart.Core.Entities
{
    public class CartDetail: BaseEntity
    {
        [Required]
        public Guid CartHeaderId { get; set; }
        public virtual CartHeader CartHeader { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Count { get; set; }
    }
}
