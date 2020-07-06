
namespace ServiceLayer.DataTransferObjects
{
    public class ProductDto<TId> : ItemDto<TId>
    {   
        public string Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}