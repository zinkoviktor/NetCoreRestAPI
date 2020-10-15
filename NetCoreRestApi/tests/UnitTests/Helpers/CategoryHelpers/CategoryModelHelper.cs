using DataLayer.Models;
using System.Collections.Generic;

namespace UnitTests.Helpers.CategoryHelpers
{
    public class CategoryModelHelper : BaseComparer<CategoryModel>
    {
        public static readonly CategoryModelHelper Instance = new CategoryModelHelper();

        private CategoryModelHelper()
        {
        }

        public override bool AreEquals(CategoryModel model1, CategoryModel model2)
        {            
            return Instance.AreObjectTypesEquals(model1, model2) 
                && model1.Id == model2.Id
                    && model1.Name == model2.Name
                        && model1.Description == model2.Description;
        }

        public static List<CategoryModel> GetCategoryModels()
        {
            var categoryModels = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."                   
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryModel()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };

            return categoryModels;
        }
    }
}
