using System.Collections.Generic;

namespace DataLayer.Models
{
    public class ProductModel : BaseModel
    {     
        public ICollection<CategoryModel> CategoryList { get; set; } = new List<CategoryModel>();
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
