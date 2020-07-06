using Common.Converters;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.Converters
{
    public class ProductServiceConverter<TId> : BaseConverter<ProductDto<TId>, ProductModel<TId>> 
    {
        public override Expression<Func<ProductDto<TId>, ProductModel<TId>>> ConvertToExpression =>
            (productDTO) => new ProductModel<TId>()
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                CategoryList = ConvertToCategoryList(productDTO),
                AvailableCount = productDTO.AvailableCount
            };

        public override Expression<Func<ProductModel<TId>, ProductDto<TId>>> ConvertFromExpression =>
            (productModel) => new ProductDto<TId>()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = ConvertToCategories(productModel),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };

        private static List<CategoryModel<TId>> ConvertToCategoryList(ProductDto<TId> productDTO)
        {
            var categoryModels = new List<CategoryModel<TId>>();
            productDTO.Categories ??= "";
            var categoryList = productDTO.Categories.Split(",");

            if (categoryList.Length == 0)
            {
                return categoryModels;
            }

            for (var i = 1; i < categoryList.Length; i++)
            {
                categoryModels.Add(new CategoryModel<TId>() { Id = GetId(), Name = categoryList[i] });
            }

            return categoryModels;
        }

        private static string ConvertToCategories(ProductModel<TId> productModel)
        {
            productModel.CategoryList ??= new List<CategoryModel<TId>>();
            var categoryList = new List<CategoryModel<TId>>(productModel.CategoryList);

            return string.Join(", ", categoryList.ConvertAll(x => x.Name));
        }

        private static TId GetId()
        {
            throw new NotImplementedException();
        }
    }
}