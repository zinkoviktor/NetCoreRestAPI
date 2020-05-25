using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;

namespace DataLayer.Converters
{
    public class CategoryEntityConverter : IConverter<CategoryEntity, CategoryModel>
    {
        public CategoryModel ConvertFrom(CategoryEntity categoryEntity)
        {
            var categoryModel = new CategoryModel()
            {
                ID = categoryEntity.ID,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };
            return categoryModel;
        }

        public CategoryEntity ConvertTo(CategoryModel categoryModel)
        {
            var categoryEntity = new CategoryEntity()
            {
                ID = categoryModel.ID,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
            return categoryEntity;
        }
    }
}
