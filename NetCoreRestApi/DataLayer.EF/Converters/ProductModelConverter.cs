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
                CategoryList = ConvertFromProductCategoriesEntities(productEntity.ProductCategory),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };

        public override Expression<Func<ProductModel, ProductEntity>> ConvertFromExpression =>
            (productModel) => new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                ProductCategory = ConvertToProductCategoriesEntities(productModel, productModel.CategoryList),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };

        private ICollection<ProductCategory> ConvertToProductCategoriesEntities(ProductModel productModel, 
            IEnumerable<CategoryModel> categories)
        {
            var productCategoriesEntities = new List<ProductCategory>();

            foreach(var categoryModel in categories)
            {
                productCategoriesEntities.Add(new ProductCategory
                {
                    Product = ConvertFrom(productModel),
                    Category = _categoryConverter.ConvertFrom(categoryModel)
                });
            }

            return productCategoriesEntities;
        }

        private IEnumerable<CategoryModel> ConvertFromProductCategoriesEntities(ICollection<ProductCategory> productCategory)
        {
            var categoryEntities = productCategory.Select(pc => pc.Category).ToList();

            return _categoryConverter.ConvertTo(categoryEntities);
        }
    }
}
