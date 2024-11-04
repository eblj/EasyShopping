using EasyShopping.Product.Application.DTOs.Filter;

namespace EasyShopping.Product.Application.Abstractions
{
    public class PagedResult<T> where T : class
    {
        public IList<T> Records { get; set; } = new List<T>();
        public FilterViewModel Filter { get; set; }        

        public PagedResult(IList<T> records, FilterViewModel filter)
        {
            this.Filter = filter;
            this.Records = records;            

            if (filter.TotalRecords > 0 && filter.RecordsByPage != 0)
                this.Filter.TotalPages = (int)Math.Ceiling((decimal)filter.TotalRecords / (decimal)filter.RecordsByPage);
        }
    }
}
