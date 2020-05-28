using Common.Converter;
using DataLayer.Models;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public class ProductConverter : IConverter<ProductModel, ProductDTO> 
    {
        public ProductModel ConvertTo(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return null;
            }
            productDTO.Categories ??= "";
            var categoryList = productDTO.Categories.Split(",");
            ProductModel productModel = new ProductModel
            {
                Id = productDTO.Id,
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

        public ProductDTO ConvertFrom(ProductModel productModel)
        {
            if (productModel == null)
            {
                return null;
            }
            productModel.CategoryList ??= new List<CategoryModel>();
            var productDTO = new ProductDTO
            {                
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Categories = string.Join(", ", productModel.CategoryList.ConvertAll(x => x.Name)),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };
            return productDTO;
        }
    }
}