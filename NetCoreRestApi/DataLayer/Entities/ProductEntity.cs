using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class ProductEntity : BaseEntity
    {      
        public ICollection<CategoryEntity> Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
