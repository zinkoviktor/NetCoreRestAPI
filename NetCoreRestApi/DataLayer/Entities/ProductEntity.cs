using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class ProductEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryEntity> Categories { get; set; }
        public decimal Price { get; set; }
        public int AvialebleCount { get; set; }
    }
}
