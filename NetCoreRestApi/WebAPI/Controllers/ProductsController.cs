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
        private IProductConverter _productConverter;
        private IProductManager _productManager;

        public ProductsController(IProductConverter productConverter, IProductManager productManager)
        {
            _productConverter = productConverter;
            _productManager = productManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {            
            var products = _productManager.GetAll();            
            if (products == null)
            {
                return NoContent();
            }
            var productsDTO = products.ToList().ConvertAll(x => _productConverter.ConverToDTO(x));
            return Ok(productsDTO);
        }
    }
}