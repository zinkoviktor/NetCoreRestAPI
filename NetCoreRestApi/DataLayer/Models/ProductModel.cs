using System.Collections.Generic;

namespace DataLayer.Models
{
    public class ProductModel<T> : ItemModel<T>
    {     
        public ICollection<CategoryModel<T>> CategoryList { get; set; } =
            new List<CategoryModel<T>>();
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
