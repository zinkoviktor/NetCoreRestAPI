using Common.Converter;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public class ProductServiceConverter : IConverter<ProductDTO, ProductModel> 
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

        public ICollection<ProductModel> ConvertTo(ICollection<ProductDTO> productDtoList)
        {
            var productModels = new List<ProductModel>();
            if(productDtoList != null)
            {
                foreach(var productDTO in productDtoList)
                {
                    productModels.Add(ConvertTo(productDTO));
                }
            }
            return productModels;
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

        public ICollection<ProductDTO> ConvertFrom(ICollection<ProductModel> productModels)
        {
            var productDtoList = new List<ProductDTO>();
            if(productModels != null)
            {
                foreach(var productModel in productModels)
                {
                    productDtoList.Add(ConvertFrom(productModel));
                }
            }
            return productDtoList;
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
            var categoryList = new List<CategoryModel>(productModel.CategoryList);
            return string.Join(", ", categoryList.ConvertAll(x => x.Name));
        }
    }
}