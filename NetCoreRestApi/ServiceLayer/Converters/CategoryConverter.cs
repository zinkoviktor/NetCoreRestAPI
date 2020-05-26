using DataLayer.Models;
using Common.Converter;
using ServiceLayer.DataTransferObjects;

namespace ServiceLayer.Converters
{
    public class CategoryConverter : IConverter<CategoryDTO, CategoryModel>
    {
        public CategoryModel ConvertFrom(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return null;
            }
            var categoryModel = new CategoryModel
            {
                ID = categoryDTO.ID,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };         
            return categoryModel;
        }

        public CategoryDTO ConvertTo(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return null;
            }
            var categoryDTO = new CategoryDTO()
            {
                ID = categoryModel.ID,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
            return categoryDTO;
        }
    }
}
