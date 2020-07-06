using Common.Converters;
using DataLayer.Entities;
using DataLayer.Models;
using System;
using System.Linq.Expressions;

namespace DataLayer.Converters
{
    public class CategoryModelConverter<TId> : BaseConverter<CategoryEntity<TId>, CategoryModel<TId>>
    {       
        public override Expression<Func<CategoryEntity<TId>, CategoryModel<TId>>> ConvertToExpression => 
            (categoryEntity) => new CategoryModel<TId>()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };        

        public override Expression<Func<CategoryModel<TId>, CategoryEntity<TId>>> ConvertFromExpression =>
            (categoryModel) => new CategoryEntity<TId>()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
    }
}
