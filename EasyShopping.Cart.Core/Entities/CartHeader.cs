using System.ComponentModel.DataAnnotations;

namespace EasyShopping.Cart.Core.Entities
{
    public class CartHeader: BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [StringLength(30)]
        public string CouponCode { get; set; }
    }
}
