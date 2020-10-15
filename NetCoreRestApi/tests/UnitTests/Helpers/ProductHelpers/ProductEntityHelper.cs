using DataLayer.EF.Entities;
using System.Collections.Generic;

namespace UnitTests.Helpers.ProductHelpers
{
    public class ProductEntityHelper : BaseComparer<ProductEntity>
    {
        public static readonly ProductEntityHelper Instance = new ProductEntityHelper();

        private ProductEntityHelper()
        {
        }

        public override bool AreEquals(ProductEntity entity1, ProductEntity entity2)
        {
            return Instance.AreObjectTypesEquals(entity1, entity2)
               && entity1.Id == entity2.Id
                   && entity1.Name == entity2.Name
                       && entity1.Description == entity2.Description
                           && entity1.Price == entity2.Price
                               && entity1.AvailableCount == entity2.AvailableCount;
        }

        public static List<ProductEntity> GetProductEntities()
        {
            var productEntites = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                }
            };

            return productEntites;
        }
    }
}
