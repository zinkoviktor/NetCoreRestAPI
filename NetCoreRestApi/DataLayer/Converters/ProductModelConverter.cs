using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Converters
{
    public class ProductModelConverter : IConverter<ProductEntity, ProductModel>
    {
        private readonly IConverter<CategoryEntity, CategoryModel> _categoryConverter;

        public ProductModelConverter(IConverter<CategoryEntity, CategoryModel> categoryConverter)
        {
            _categoryConverter = categoryConverter;
        }

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
                CategoryList = _categoryConverter.ConvertTo(productEntity.Categories),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };

            return productModel;
        }

        public ICollection<ProductModel> ConvertTo(ICollection<ProductEntity> productEntities)
        {
            var productModels = new List<ProductModel>();
            if (productEntities == null)
            {
                return productModels;
            }

            foreach (var productEntity in productEntities)
            {
                productModels.Add(ConvertTo(productEntity));
            }

            return productModels;
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
                Categories = _categoryConverter.ConvertFrom(productModel.CategoryList),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };

            return productEntity;
        }

        public ICollection<ProductEntity> ConvertFrom(ICollection<ProductModel> productModels)
        {
            var productEntities = new List<ProductEntity>();

            if(productModels == null)
            {
                return productEntities;
            }

            foreach (var productModel in productModels)
            {
                productEntities.Add(ConvertFrom(productModel));
            }

            return productEntities;
        }
    }
}
