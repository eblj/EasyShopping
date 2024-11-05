using System.ComponentModel.DataAnnotations;

namespace EasyShopping.Coupon.Core.Entities
{
    public class Coupon: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
    }
}
