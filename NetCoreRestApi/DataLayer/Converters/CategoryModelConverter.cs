using Common.Converters;
using DataLayer.Entities;
using DataLayer.Models;
using System;
using System.Linq.Expressions;

namespace DataLayer.Converters
{
    public class CategoryModelConverter : BaseConvertor<CategoryEntity, CategoryModel>
    {       
        public override Expression<Func<CategoryEntity, CategoryModel>> ConvertToExpression => 
            (categoryEntity) => new CategoryModel()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };        

        public override Expression<Func<CategoryModel, CategoryEntity>> ConvertFromExpression =>
            (categoryModel) => new CategoryEntity()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
    }
}
