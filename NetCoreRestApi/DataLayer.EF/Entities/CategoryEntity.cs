
using System.Collections.Generic;

namespace DataLayer.EF.Entities
{
    public class CategoryEntity : ItemEntity<int>
    {
        public ICollection<ProductCategory> ProductCategory { get; set; }
            = new List<ProductCategory>();
    }
}
