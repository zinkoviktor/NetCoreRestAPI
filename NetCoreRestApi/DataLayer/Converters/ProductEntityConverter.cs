using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer.Converters
{
    public class ProductEntityConverter : IConverter<ProductModel, ProductEntity>
    {
        private readonly CategoryEntityConverter _categoryEntityConverter = new CategoryEntityConverter();

        public ProductModel ConvertTo(ProductEntity productEntity)
        {
            if (productEntity == null)
            {
                return null;
            }
            var productModel = new ProductModel
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                CategoryList = new List<CategoryModel>(from category in productEntity.Categories
                                                       select _categoryEntityConverter.ConvertTo(category)),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };
            return productModel;
        }

        public ProductEntity ConvertFrom(ProductModel productModel)
        {
            if (productModel == null)
            {
                return null;
            }
            var productEntity = new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = productModel.CategoryList.ConvertAll(categoryModel => _categoryEntityConverter.ConvertFrom(categoryModel)),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };
            return productEntity;
        }
    }
}
