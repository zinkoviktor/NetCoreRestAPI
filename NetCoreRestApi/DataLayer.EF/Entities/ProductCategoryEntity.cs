namespace DataLayer.EF.Entities
{
    public class ProductCategoriesEntity
    {       
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
