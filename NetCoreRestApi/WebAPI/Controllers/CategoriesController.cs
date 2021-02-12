using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using DataLayer.UnitOfWorks;
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

        [HttpGet()]
        public IActionResult Get([FromQuery] FilterParameters filter = null)
        {
            var categoryModels = Manager.GetAll(filter);
            var categoriesDTO = Converter.ConvertFrom(categoryModels.ToList());

            if (!categoriesDTO.Any())
            {
                return NotFound("Categories not found");
            }

            return Ok(categoriesDTO);
        }

        [HttpPost]
        public IActionResult Create(IEnumerable<CategoryDto> categories)
        {
            var categoryModels = Converter.ConvertTo(categories);
            var createdModels = Manager.Create(categoryModels);
            var createdCategories = Converter.ConvertFrom(createdModels.ToList());

            if (!createdCategories.Any())
            {
                return BadRequest("Categories not created!");
            }
           
            return Created(nameof(Create), new { createdCategories = createdCategories.ToArray() });
        }

        [HttpPut]
        public IActionResult Update(IEnumerable<CategoryDto> categories)
        {
            var categoryModels = Converter.ConvertTo(categories);
            var result = Manager.Update(categoryModels);

            if (!result)
            {
                return BadRequest("Categories not created!");
            }

            return Ok("Successfully updated!!!"); 
        }

        [HttpDelete]
        public IActionResult Delete(IEnumerable<CategoryDto> categories)
        {
            var categoryModels = Converter.ConvertTo(categories);
            var result = Manager.Delete(categoryModels);

            if (!result)
            {
                return BadRequest("Categories not created!");
            }

            return Ok("Successfully deleted!!!");
        }
    }
}