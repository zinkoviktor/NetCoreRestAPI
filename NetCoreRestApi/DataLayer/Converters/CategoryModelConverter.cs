using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;
using System.Collections.Generic;

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

        public ICollection<CategoryModel> ConvertTo(ICollection<CategoryEntity> categoryEntities)
        {
            var categoryModels = new List<CategoryModel>();
            if (categoryEntities == null)
            {
                return categoryModels;
            }
            foreach(var categoryEntity in categoryEntities)
            {
                categoryModels.Add(ConvertTo(categoryEntity));
            }
            return categoryModels;
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
        
        public ICollection<CategoryEntity> ConvertFrom(ICollection<CategoryModel> categoryModels)
        {
            var categoryEntities = new List<CategoryEntity>();
            if (categoryModels == null)
            {
                return categoryEntities;
            }
            foreach(var categoryModel in categoryModels)
            {
                categoryEntities.Add(ConvertFrom(categoryModel));
            }
            return categoryEntities;
        }
    }
}
