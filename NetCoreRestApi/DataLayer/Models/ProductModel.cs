using System.Collections.Generic;

namespace DataLayer.Models
{
    public class ProductModel : ItemModel<int>
    {
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
        public IEnumerable<CategoryModel> CategoryList { get; set; }
            = new List<CategoryModel>();
    }
}
