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
    public class ProductsController : ControllerBase
    {
        private IProductManager _productManager;
        private IConverter<ProductModel, ProductDTO> _converter;        

        public ProductsController(IProductManager productManager, IConverter<ProductModel, ProductDTO> converter)
        {
            _productManager = productManager;
            _converter = converter;            
        }

        [HttpGet]
        public ActionResult<IQueryable<ProductDTO>> Get()
        {            
            var products = _productManager.GetAll();            
            if (products == null)
            {
                return NoContent();
            }
            var productsDTO = products.Select(x => _converter.ConvertFrom(x));
            return Ok(productsDTO);
        }
    }
}