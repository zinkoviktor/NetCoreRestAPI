
namespace ServiceLayer.DataTransferObjects
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}