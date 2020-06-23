using System.Linq;
using BusinessLayer.Managers;
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
        private IConverter<ProductDTO, ProductModel> _converter;        

        public ProductsController(IProductManager productManager, IConverter<ProductDTO, ProductModel> converter)
        {
            _productManager = productManager;
            _converter = converter;            
        }

        [HttpGet]
        public IActionResult Get()
        {            
            var productModels = _productManager.GetAll();
            var productsDTO = _converter.ConvertFrom(productModels.ToList());

            return Ok(productsDTO);
        }
    }
}