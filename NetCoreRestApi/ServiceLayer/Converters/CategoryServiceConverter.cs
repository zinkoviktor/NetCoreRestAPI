using Common.Converters;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Linq.Expressions;

namespace ServiceLayer.Converters
{
    public class CategoryServiceConverter : BaseConverter<CategoryDTO, CategoryModel>
    {
        public override Expression<Func<CategoryDTO, CategoryModel>> ConvertToExpression =>
            (categoryDTO) => new CategoryModel()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };

        public override Expression<Func<CategoryModel, CategoryDTO>> ConvertFromExpression =>
            (categoryModel) => new CategoryDTO()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
    }
}
