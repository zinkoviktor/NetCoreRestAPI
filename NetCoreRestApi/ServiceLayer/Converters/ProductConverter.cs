using Common.Converter;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public class ProductConverter : IConverter<ProductDTO, ProductModel> 
    {
        public ProductDTO ConvertTo(ProductModel productModel)
        {
            if (productModel == null)
            {
                return null;
            }
            productModel.CategoryList ??= new List<CategoryModel>();
            var productDTO = new ProductDTO
            {                
                ID = productModel.ID,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = string.Join(", ", productModel.CategoryList.ConvertAll(x => x.Name)),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };
            return productDTO;
        }       

        public ProductModel ConvertFrom(ProductDTO productDTO)
        {
            if (productDTO == null)
            { 
                return null; 
            }
            productDTO.Categories ??= "";
            var categoryList = productDTO.Categories.Split(",");
            ProductModel productModel = new ProductModel
            {
                ID = productDTO.ID,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                AvailableCount = productDTO.AvailableCount               
            };
            foreach (var category in categoryList)
            {
                productModel.CategoryList.Add(new CategoryModel() { Name = category });
            }                      
            return productModel;
        }
    }
}