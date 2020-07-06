using Common.Converters;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Linq.Expressions;

namespace ServiceLayer.Converters
{
    public class CategoryServiceConverter<TId> : BaseConverter<CategoryDto<TId>, CategoryModel<TId>>
    {
        public override Expression<Func<CategoryDto<TId>, CategoryModel<TId>>> ConvertToExpression =>
            (categoryDTO) => new CategoryModel<TId>()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };

        public override Expression<Func<CategoryModel<TId>, CategoryDto<TId>>> ConvertFromExpression =>
            (categoryModel) => new CategoryDto<TId>()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
    }
}
