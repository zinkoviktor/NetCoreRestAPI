using DataLayer.Models;
using Common.Converter;
using ServiceLayer.DataTransferObjects;

namespace ServiceLayer.Converters
{
    public class CategoryConverter : IConverter<CategoryModel, CategoryDTO>
    {
        public CategoryModel ConvertTo(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return null;
            }
            var categoryModel = new CategoryModel
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };         
            return categoryModel;
        }

        public CategoryDTO ConvertFrom(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return null;
            }
            var categoryDTO = new CategoryDTO()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
            return categoryDTO;
        }
    }
}
