using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;

namespace DataLayer.Converters
{
    public class CategoryEntityConverter : IConverter<CategoryModel, CategoryEntity>
    {
        public CategoryEntity ConvertTo(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return null;
            }
            var categoryEntity = new CategoryEntity()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
            return categoryEntity;
        }

        public CategoryModel ConvertFrom(CategoryEntity categoryEntity)
        {
            if (categoryEntity == null)
            {
                return null;
            }
            var categoryModel = new CategoryModel()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };
            return categoryModel;
        }        
    }
}
