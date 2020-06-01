using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;

namespace DataLayer.Converters
{
    public class CategoryModelConverter : IConverter<CategoryEntity, CategoryModel>
    {
        public CategoryModel ConvertTo(CategoryEntity categoryEntity)
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

        public CategoryEntity ConvertFrom(CategoryModel categoryModel)
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
    }
}
