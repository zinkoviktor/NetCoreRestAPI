
namespace BusinessLayer.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
