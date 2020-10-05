using Common.Converters;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.Converters
{
    public class ProductServiceConverter : BaseConverter<ProductDto, ProductModel>
    {
        public override Expression<Func<ProductDto, ProductModel>> ConvertToExpression =>
            (productDTO) => new ProductModel()
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                CategoryList = ConvertToCategoryList(productDTO),
                AvailableCount = productDTO.AvailableCount
            };

        public override Expression<Func<ProductModel, ProductDto>> ConvertFromExpression =>
            (productModel) => new ProductDto()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = ConvertToCategories(productModel),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };

        private static List<CategoryModel> ConvertToCategoryList(ProductDto productDTO)
        {
            var categoryModels = new List<CategoryModel>();
            productDTO.Categories ??= "";
            var categoryList = productDTO.Categories.Split(",");

            if (categoryList.Length == 0)
            {
                return categoryModels;
            }

            for (var i = 0; i < categoryList.Length; i++)
            {
                categoryModels.Add(new CategoryModel() { Name = categoryList[i].Trim() });
            }

            return categoryModels;
        }

        private static string ConvertToCategories(ProductModel productModel)
        {
            productModel.CategoryList ??= new List<CategoryModel>();
            var categoryList = new List<CategoryModel>(productModel.CategoryList);

            return string.Join(", ", categoryList.ConvertAll(x => x.Name));
        }
    }
}