namespace EasyShopping.Coupon.Application.DTOs.Coupon
{
    public class CouponViewModel: BaseViewModel
    {
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime Validate { get; set; }
    }
}
