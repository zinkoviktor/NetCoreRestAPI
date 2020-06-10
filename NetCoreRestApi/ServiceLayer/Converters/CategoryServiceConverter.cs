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

        public ICollection<CategoryModel> ConvertTo(ICollection<CategoryDTO> categoryDtoList)
        {
            var categoryModels = new List<CategoryModel>();
            if (categoryDtoList != null)
            {
                foreach (var categoryDTO in categoryDtoList)
                {
                    categoryModels.Add(ConvertTo(categoryDTO));
                }
            }
            return categoryModels;
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
                
        public ICollection<CategoryDTO> ConvertFrom(ICollection<CategoryModel> categoryModels)
        {
            var categoryDtoList = new List<CategoryDTO>();
            if(categoryModels != null)
            {
                foreach(var categoryModel in categoryModels)
                {
                    categoryDtoList.Add(ConvertFrom(categoryModel));
                }
            }
            return categoryDtoList;
        }
    }
}
