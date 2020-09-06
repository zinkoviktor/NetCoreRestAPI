using System.Collections.Generic;

namespace DataLayer.EF.Entities
{
    public class ProductEntity : ItemEntity<int>
    {
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
        public ICollection<ProductCategoryEntity> ProductCategoryEntities { get; set; }
    }
}
