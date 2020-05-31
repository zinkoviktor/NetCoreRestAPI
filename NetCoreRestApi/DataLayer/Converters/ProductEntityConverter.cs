using DataLayer.Models;
using Common.Converter;
using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Converters
{
    public class ProductEntityConverter : IConverter<ProductModel, ProductEntity>
    {
        private readonly IConverter<CategoryModel, CategoryEntity> _categoryConverter;

        public ProductEntityConverter(IConverter<CategoryModel, CategoryEntity> categoryConverter)
        {
            _categoryConverter = categoryConverter;
        }

        public ProductEntity ConvertTo(ProductModel productModel)
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
                Categories = ConvertToCategories(productModel, _categoryConverter),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };
            return productEntity;
        }

        public ProductModel ConvertFrom(ProductEntity productEntity)
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
                CategoryList = ConvertToCategoryList(productEntity, _categoryConverter),
                AvailableCount = productEntity.AvailableCount,
                Price = productEntity.Price
            };
            return productModel;
        }

        private static ICollection<CategoryEntity> ConvertToCategories(ProductModel productModel, IConverter<CategoryModel, CategoryEntity> converter)
        {
            return productModel.CategoryList.ConvertAll(categoryModel => converter.ConvertTo(categoryModel));
        }

        private static List<CategoryModel> ConvertToCategoryList(ProductEntity productEntity, IConverter<CategoryModel, CategoryEntity> converter)
        {
            var categoryModelList = new List<CategoryModel>();
            foreach (var categoryEntity in productEntity.Categories)
            {
                categoryModelList.Add(converter.ConvertFrom(categoryEntity));
            }
            return categoryModelList;           
        }
    }
}
