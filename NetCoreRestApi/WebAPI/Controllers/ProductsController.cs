using BusinessLayer.Interfaces;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<ProductDto<int>, ProductModel<int>>
    {
        public ProductsController(IManager<ProductModel<int>> manager, IConverter<ProductDto<int>, ProductModel<int>> converter) 
            : base(manager, converter)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {            
            var productModels = Manager.GetAll();
            var productsDTO = Converter.ConvertFrom(productModels.ToList());

            return Ok(productsDTO);
        }
    }
}