using Common.Converters;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.Converters
{
    public class ProductServiceConverter : BaseConverter<ProductDTO, ProductModel> 
    {
        public override Expression<Func<ProductDTO, ProductModel>> ConvertToExpression =>
            (productDTO) => new ProductModel()
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                CategoryList = ConvertToCategoryList(productDTO),
                AvailableCount = productDTO.AvailableCount
            };

        public override Expression<Func<ProductModel, ProductDTO>> ConvertFromExpression =>
            (productModel) => new ProductDTO()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = ConvertToCategories(productModel),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };

        private static List<CategoryModel> ConvertToCategoryList(ProductDTO productDTO)
        {
            var categoryModels = new List<CategoryModel>();
            productDTO.Categories ??= "";
            var categoryList = productDTO.Categories.Split(",");

            if (categoryList.Length == 0)
            {
                return categoryModels;
            }

            for (var i = 1; i < categoryList.Length; i++)
            {
                categoryModels.Add(new CategoryModel() { Id = i, Name = categoryList[i] });
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