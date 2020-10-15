using DataLayer.EF.Entities;
using System.Collections.Generic;

namespace UnitTests.Helpers.CategoryHelpers
{
    public class CategoryEntityHelper : BaseComparer<CategoryEntity>
    {
        public static readonly CategoryEntityHelper Instance = new CategoryEntityHelper();

        private CategoryEntityHelper()
        {
        }

        public override bool AreEquals(CategoryEntity entity1, CategoryEntity entity2)
        {
            return Instance.AreObjectTypesEquals(entity1, entity2)
                && entity1.Id == entity2.Id
                    && entity1.Name == entity2.Name
                        && entity1.Description == entity2.Description;
        }

        public static List<CategoryEntity> GetCategoryEntities()
        {
            var categoryEntities = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money.",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new CategoryEntity()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020.",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new CategoryEntity()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                }
            };

            return categoryEntities;
        }
    }
}
