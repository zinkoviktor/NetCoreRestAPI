using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;
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
    }
}