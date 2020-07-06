using Common.Converter;
using Common.Converters;
using DataLayer.Entities;
using DataLayer.Models;
using System;
using System.Linq.Expressions;

namespace DataLayer.Converters
{
    public class ProductModelConverter<TId> : BaseConverter<ProductEntity<TId>, ProductModel<TId>>
    {
        private readonly IConverter<CategoryEntity<TId>, CategoryModel<TId>> _categoryConverter;
        
        public ProductModelConverter(IConverter<CategoryEntity<TId>, CategoryModel<TId>> categoryConverter)
        {
            _categoryConverter = categoryConverter;
        }

        public override Expression<Func<ProductEntity<TId>, ProductModel<TId>>> ConvertToExpression =>
            (productEntity) => new ProductModel<TId>()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                CategoryList = _categoryConverter.ConvertTo(productEntity.Categories),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };

        public override Expression<Func<ProductModel<TId>, ProductEntity<TId>>> ConvertFromExpression =>
            (productModel) => new ProductEntity<TId>()
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
