namespace EasyShopping.Cart.Application.DTOs
{
    public class CartHeaderViewModel: BaseViewModel
    {
        public Guid UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
