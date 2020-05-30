using System.Linq;
using BusinessLayer.Manager;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;

namespace WebAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryManager _categoryManager;
        private IConverter<CategoryDTO, CategoryModel> _converter;
        
        public CategoriesController(ICategoryManager categoryManager, IConverter<CategoryDTO, CategoryModel> converter)
        {            
            _categoryManager = categoryManager;
            _converter = converter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _categoryManager.GetAll();           
            var productsDTO = products.Select(x => _converter.ConvertFrom(x));
            return Ok(productsDTO);
        }
    }
}