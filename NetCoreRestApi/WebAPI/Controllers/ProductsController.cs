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
        private IConverter<ProductDTO, ProductModel> _converter;
        private IProductManager _productManager;

        public ProductsController(IConverter<ProductDTO, ProductModel>  converter, IProductManager productManager)
        {
            _converter = converter;
            _productManager = productManager;
        }

        [HttpGet]
        public ActionResult<IQueryable<ProductDTO>> Get()
        {            
            var products = _productManager.GetAll();            
            if (products == null)
            {
                return NoContent();
            }
            var productsDTO = products.Select(x => _converter.ConvertTo(x));
            return Ok(productsDTO);
        }
    }
}