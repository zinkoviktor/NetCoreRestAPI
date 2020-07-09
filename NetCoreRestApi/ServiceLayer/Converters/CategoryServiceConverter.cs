using Common.Converters;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Linq.Expressions;

namespace ServiceLayer.Converters
{
    public class CategoryServiceConverter : BaseConverter<CategoryDto, CategoryModel>
    {
        public override Expression<Func<CategoryDto, CategoryModel>> ConvertToExpression =>
            (categoryDTO) => new CategoryModel()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };

        public override Expression<Func<CategoryModel, CategoryDto>> ConvertFromExpression =>
            (categoryModel) => new CategoryDto()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
    }
}
