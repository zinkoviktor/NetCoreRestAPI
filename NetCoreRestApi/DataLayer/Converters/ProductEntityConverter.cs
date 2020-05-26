using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer.Converters
{
    public class ProductEntityConverter : IConverter<ProductEntity, ProductModel>
    {
        private readonly CategoryEntityConverter _categoryEntityConverter = new CategoryEntityConverter();

        public ProductModel ConvertFrom(ProductEntity productEntity)
        {
            if (productEntity == null)
            {
                return null;
            }
            var productModel = new ProductModel
            {
                ID = productEntity.ID,
                Name = productEntity.Name,
                Description = productEntity.Description,
                CategoryList = new List<CategoryModel>(from category in productEntity.Categories 
                                                       select _categoryEntityConverter.ConvertFrom(category)),
                AvailableCount = productEntity.AvialebleCount,
                Price = productEntity.Price
            };
            return productModel;
        }

        public ProductEntity ConvertTo(ProductModel productModel)
        {
            if (productModel == null)
            {
                return null;
            }
            var productEntity = new ProductEntity()
            {
                ID = productModel.ID,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = productModel.CategoryList.ConvertAll(categoryModel => _categoryEntityConverter.ConvertTo(categoryModel)),
                AvialebleCount = productModel.AvailableCount,
                Price = productModel.Price
            };
            return productEntity;
        }
    }
}
