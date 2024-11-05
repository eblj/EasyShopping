namespace EasyShopping.Cart.Application.DTOs
{
    public class ProductViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
