using BusinessLayer.Models;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public class ProductConverter
    {
        public ProductDTO ConverToDTO(ProductModel productModel)
        {            
            if (productModel == null) return null;
            productModel.CategoryList ??= new List<CategoryModel>();
            ProductDTO productDTO = new ProductDTO
            {
                Name = productModel.Name,
                Description = productModel.Description,
                CategoryList = string.Join(", ", productModel.CategoryList.ConvertAll(x => x.Name)),
                Price = productModel.Price,
                AvailableCount = productModel.AvailableCount
            };
            return productDTO;
        }       

        public ProductModel ConverToModel(ProductDTO productDTO)
        {
            if (productDTO == null) return null;
            productDTO.CategoryList ??= "";
            var categoryList = productDTO.CategoryList.Split(",");
            ProductModel productModel = new ProductModel
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                AvailableCount = productDTO.AvailableCount,
                CategoryList = new List<CategoryModel>()
            };
            if (categoryList[0].Length > 0)
            {
                foreach (var category in categoryList)
                {
                    productModel.CategoryList.Add(new CategoryModel() { Name = category });
                }
            }            
            return productModel;
        }
    }
}