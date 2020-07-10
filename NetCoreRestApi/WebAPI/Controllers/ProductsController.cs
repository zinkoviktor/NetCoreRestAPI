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
    public class ProductsController : GenericController<ProductDto, ProductModel>
    {
        public ProductsController(IProductManager manager, 
            IConverter<ProductDto, ProductModel> converter) : base(manager, converter)
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