using System.Collections.Generic;

namespace DataLayer.Models
{
    public class ProductModel : ItemModel<int>
    {     
        public ICollection<CategoryModel> CategoryList { get; set; } =
            new List<CategoryModel>();
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
