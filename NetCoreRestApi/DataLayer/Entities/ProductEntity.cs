using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class ProductEntity<T> : ItemEntity<T>
    {      
        public ICollection<CategoryEntity<T>> Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
