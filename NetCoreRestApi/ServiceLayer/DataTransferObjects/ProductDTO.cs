
namespace ServiceLayer.DataTransferObjects
{
    public class ProductDto : ItemDto<int>
    {
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
        public string Categories { get; set; }
    }
}