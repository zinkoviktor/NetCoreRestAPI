using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Manager;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            ProductManager productManager = new ProductManager();
            var products = productManager.GetAll();
            ProductConverter productConverter = new ProductConverter();
            if (products == null) return NoContent();
            var productsDTO = products.ToList().ConvertAll(x => productConverter.ConverToDTO(x));
            return Ok(productsDTO);
        }
    }
}