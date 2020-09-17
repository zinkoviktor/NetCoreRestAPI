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
            (productModel) => ConvertToEntity(productModel);

        private ProductEntity ConvertToEntity(ProductModel productModel)
        {
            var productEntity = new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };

            var productCategoryEntities = new List<ProductCategoryEntity>();            

            foreach (var categoryModel in productModel.CategoryList)
            {
                var categoryEntity = _categoryConverter.ConvertFrom(categoryModel);               
                productCategoryEntities.Add(new ProductCategoryEntity
                {                    
                    Category = categoryEntity,
                    CategoryId = categoryEntity.Id
                });
            }

            foreach (var productCategoryEntity in productCategoryEntities)
            {
                productCategoryEntity.Product = productEntity;
                productCategoryEntity.ProductId = productEntity.Id;
            }

            productEntity.ProductCategoryEntities = productCategoryEntities;

            return productEntity;
        }

        private IEnumerable<CategoryModel> ConvertFromProductCategoryEntities(ICollection<ProductCategoryEntity> productCategory)
        {
            var categoryEntities = productCategory.Select(pc => pc.Category).ToList();

            return _categoryConverter.ConvertTo(categoryEntities);
        }
    }
}
