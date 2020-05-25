using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Manager;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;

namespace WebAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IConverter<CategoryDTO, CategoryModel> _converter;
        private ICategoryManager _categoryManager;

        public CategoriesController(IConverter<CategoryDTO, CategoryModel> converter, ICategoryManager categoryManager)
        {
            _converter = converter;
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public ActionResult<IQueryable<CategoryDTO>> Get()
        {
            var products = _categoryManager.GetAll();
            if (products == null)
            {
                return NoContent();
            }
            var productsDTO = products.Select(x => _converter.ConvertTo(x));
            return Ok(productsDTO);
        }
    }
}