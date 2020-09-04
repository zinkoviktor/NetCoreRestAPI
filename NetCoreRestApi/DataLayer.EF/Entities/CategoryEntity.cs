
using System.Collections.Generic;

namespace DataLayer.EF.Entities
{
    public class CategoryEntity : ItemEntity<int>
    {
        public ICollection<ProductCategoryEntity> ProductCategoryEntities { get; set; }
            = new List<ProductCategoryEntity>();
    }
}
