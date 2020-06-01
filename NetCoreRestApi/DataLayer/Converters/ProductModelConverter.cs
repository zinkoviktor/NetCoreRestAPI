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
                CategoryList = ConvertToCategoryList(productEntity, _categoryConverter),
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
                Categories = ConvertToCategories(productModel, _categoryConverter),
                AvailableCount = productModel.AvailableCount,
                Price = productModel.Price
            };
            return productEntity;
        }

        private static List<CategoryModel> ConvertToCategoryList(ProductEntity productEntity, IConverter<CategoryEntity, CategoryModel> converter)
        {
            var categoryModelList = new List<CategoryModel>();
            foreach (var categoryEntity in productEntity.Categories)
            {
                categoryModelList.Add(converter.ConvertTo(categoryEntity));
            }
            return categoryModelList;
        }

        private static ICollection<CategoryEntity> ConvertToCategories(ProductModel productModel, IConverter<CategoryEntity, CategoryModel> converter)
        {
            return productModel.CategoryList.ConvertAll(categoryModel => converter.ConvertFrom(categoryModel));
        }
    }
}
