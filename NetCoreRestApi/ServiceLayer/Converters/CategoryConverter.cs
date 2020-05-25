using DataLayer.Models;
using Common.Converter;
using ServiceLayer.DataTransferObjects;

namespace ServiceLayer.Converters
{
    public class CategoryConverter : IConverter<CategoryDTO, CategoryModel>
    {
        public CategoryModel ConvertFrom(CategoryDTO categoryDTO)
        {
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
