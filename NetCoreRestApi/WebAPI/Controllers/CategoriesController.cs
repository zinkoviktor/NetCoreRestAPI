using System.Linq;
using BusinessLayer.Interfaces;
using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;

namespace WebAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : GenericController<CategoryDto<int>, CategoryModel<int>>
    {       
        public CategoriesController(IManager<CategoryModel<int>> manager, 
            IConverter<CategoryDto<int>, CategoryModel<int>> converter) : base(manager, converter)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categoryModels = Manager.GetAll();           
            var categoriesDTO = Converter.ConvertFrom(categoryModels.ToList());

            return Ok(categoriesDTO);
        }
    }
}