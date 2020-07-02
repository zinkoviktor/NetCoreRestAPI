
namespace ServiceLayer.DataTransferObjects
{
    public class ProductDTO : BaseDto
    {   
        public string Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}