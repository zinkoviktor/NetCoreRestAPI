
namespace ServiceLayer.DataTransferObjects
{
    public class ProductDto : ItemDto<int>
    {   
        public string Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}