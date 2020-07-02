using Common.Converter;
using Common.Converters;
using DataLayer.Entities;
using DataLayer.Models;
using System;
using System.Linq.Expressions;

namespace DataLayer.Converters
{
    public class ProductModelConverter : BaseConvertor<ProductEntity, ProductModel>
    {
        private readonly IConverter<CategoryEntity, CategoryModel> _categoryConverter;
        
        public ProductModelConverter(IConverter<CategoryEntity, CategoryModel> categoryConverter)
        {
            _categoryConverter = categoryConverter;
        }

        public override Expression<Func<ProductEntity, ProductModel>> ConvertToExpression =>
            (productEntity) => new ProductModel()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                CategoryList = _categoryConverter.ConvertTo(productEntity.Categories),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };

        public override Expression<Func<ProductModel, ProductEntity>> ConvertFromExpression =>
            (productModel) => new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = _categoryConverter.ConvertFrom(productModel.CategoryList),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };
    }
}
