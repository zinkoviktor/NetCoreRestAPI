using Common.Converter;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public class ProductModelConverter : IConverter<ProductDTO, ProductModel> 
    {
        public ProductModel ConvertTo(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return null;
            }            
            ProductModel productModel = new ProductModel
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                CategoryList = ConvertToCategoryList(productDTO),
                AvailableCount = productDTO.AvailableCount
            };           
            return productModel;
        }

        public ProductDTO ConvertFrom(ProductModel productModel)
        {
            if (productModel == null)
            {
                return null;
            }            
            var productDTO = new ProductDTO
            {                
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = ConvertToCategories(productModel),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };
            return productDTO;
        }

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
            return string.Join(", ", productModel.CategoryList.ConvertAll(x => x.Name));
        }
    }
}