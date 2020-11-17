using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : GenericController<CategoryDto, CategoryModel>
    {
        public CategoriesController(ICategoryManager manager,
            IConverter<CategoryDto, CategoryModel> converter) : base(manager, converter)
        {
        }

        [HttpGet]
        public IActionResult Get(int pageIndex, int pageSize)
        {
            var categoryModels = Manager.GetAll(pageIndex, pageSize);
            var categoriesDTO = Converter.ConvertFrom(categoryModels.ToList());

            return Ok(categoriesDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] IEnumerable<CategoryDto> categories)
        {
            var categoryModels = Converter.ConvertTo(categories);
            var createdModels = Manager.Create(categoryModels);
            Manager.Save();

            var createdCategories = Converter.ConvertFrom(createdModels.ToList());
            return Ok(createdCategories);
        }

        [HttpPut]
        public IActionResult Update([FromBody] IEnumerable<CategoryDto> categories)
        {
            var categoryModels = Converter.ConvertTo(categories);
            Manager.Update(categoryModels);
            var updatedItemsCount = Manager.Save();

            return Ok("Updated: " + updatedItemsCount);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] IEnumerable<CategoryDto> categories)
        {
            var categoryModels = Converter.ConvertTo(categories);
            Manager.Delete(categoryModels);
            var deletedItemsCount = Manager.Save();

            return Ok("Deleted: " + deletedItemsCount);
        }
    }
}