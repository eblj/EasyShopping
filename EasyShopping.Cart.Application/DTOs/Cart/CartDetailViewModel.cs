namespace EasyShopping.Cart.Application.DTOs
{
    public class CartDetailViewModel: BaseViewModel
    {
        public Guid CartHeaderId { get; set; }
        public CartHeaderViewModel CartHeader { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
