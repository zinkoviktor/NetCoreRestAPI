using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace UnitTests.Helpers.CategoryHelpers
{
    public class CategoryDtoHelper : BaseComparer<CategoryDto>
    {
        public static readonly CategoryDtoHelper Instance = new CategoryDtoHelper();

        private CategoryDtoHelper()
        {
        }

        public override bool AreEquals(CategoryDto model1, CategoryDto model2)
        {            
            return Instance.AreObjectTypesEquals(model1, model2) 
                && model1.Id == model2.Id
                    && model1.Name == model2.Name
                        && model1.Description == model2.Description;
        }        

        public static List<CategoryDto> GetCategoryDtos()
        {
            var categories = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."                   
                },
                new CategoryDto()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryDto()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };

            return categories;
        }
    }
}
