using DataLayer.Models;
using Common.Converter;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public class CategoryServiceConverter : IConverter<CategoryDTO, CategoryModel>
    {
        public CategoryModel ConvertTo(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return null;
            }
            var categoryModel = new CategoryModel
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };         
            return categoryModel;
        }

        public CategoryDTO ConvertFrom(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return null;
            }
            var categoryDTO = new CategoryDTO()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
            return categoryDTO;
        }

        public ICollection<CategoryModel> ConvertTo(ICollection<CategoryDTO> t1)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<CategoryDTO> ConvertFrom(ICollection<CategoryModel> t2)
        {
            throw new System.NotImplementedException();
        }
    }
}
