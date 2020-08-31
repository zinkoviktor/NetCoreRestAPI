
using System.Collections.Generic;

namespace DataLayer.EF.Entities
{
    public class CategoryEntity : ItemEntity<int>
    {
        public ICollection<ProductCategoriesEntity> ProductCategoriesEntities { get; set; }
            = new List<ProductCategoriesEntity>();
    }
}
