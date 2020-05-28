using System.Collections.Generic;

namespace DataLayer.Models
{
    public class ProductModel
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryModel> CategoryList { get; set; } = new List<CategoryModel>();
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
