using Common.Converter;
using Common.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataLayer.EF.Converters
{
    public class ProductModelConverter : BaseConverter<ProductEntity, ProductModel>
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
                CategoryList = ConvertFromProductCategoryEntities(productEntity.ProductCategoryEntities),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };

        public override Expression<Func<ProductModel, ProductEntity>> ConvertFromExpression =>
            (productModel) => new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                ProductCategoryEntities = ConvertToProductCategoryEntities(productModel, productModel.CategoryList),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };

        private ICollection<ProductCategoryEntity> ConvertToProductCategoryEntities(ProductModel productModel, 
            IEnumerable<CategoryModel> categories)
        {
            var productCategoryEntities = new List<ProductCategoryEntity>();

            foreach(var categoryModel in categories)
            {
                productCategoryEntities.Add(new ProductCategoryEntity
                {
                    Product = ConvertFrom(productModel),
                    Category = _categoryConverter.ConvertFrom(categoryModel)
                });
            }

            return productCategoryEntities;
        }

        private IEnumerable<CategoryModel> ConvertFromProductCategoryEntities(ICollection<ProductCategoryEntity> productCategory)
        {
            var categoryEntities = productCategory.Select(pc => pc.Category).ToList();

            return _categoryConverter.ConvertTo(categoryEntities);
        }
    }
}
