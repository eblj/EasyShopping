using EasyShopping.Product.Application.Enums;

namespace EasyShopping.Product.Application.DTOs.Filter
{
    public class FilterViewModel
    {
        public int CurrentPage { get; set; }
        public int RecordsByPage { get; set; }
        public int TotalRecords { get; set; }
        public string SearchBy { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public DirecaoOrdenacaoEnum Direction { get; set; }
        public int TotalPages { get; set; }
    }
}
