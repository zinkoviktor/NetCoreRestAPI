using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using DataLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
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

        [HttpGet()]
        public IActionResult Get([FromQuery] FilterParameters filter = null)
        {            
            var productModels = Manager.GetAll(filter);
            var productsDTO = Converter.ConvertFrom(productModels.ToList());
            return Ok(productsDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] IEnumerable<ProductDto> productDtos)
        {
            var productModels = Converter.ConvertTo(productDtos);
            var createdModels = Manager.Create(productModels);
            var createdProducts = Converter.ConvertFrom(createdModels.ToList());
            return Ok(createdProducts);
        }

        [HttpPut]
        public IActionResult Update([FromBody] IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            Manager.Update(productModels);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            Manager.Delete(productModels);
            return Ok();
        }
    }
}