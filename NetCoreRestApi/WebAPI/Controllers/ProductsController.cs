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

        [HttpGet("/")]
        public IActionResult Get([FromQuery] FilterParameters filter)
        {            
            var productModels = Manager.GetAll(filter);
            var productsDTO = Converter.ConvertFrom(productModels.ToList());

            return Ok(productsDTO);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Get(null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            var createdModels = Manager.Create(productModels);
            Manager.Save();

            var createdProducts = Converter.ConvertFrom(createdModels.ToList());
            return Ok(createdProducts);
        }

        [HttpPut]
        public IActionResult Update([FromBody] IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            Manager.Update(productModels);
            var updatedItemsCount = Manager.Save();

            return Ok("Updated: " + updatedItemsCount);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            Manager.Delete(productModels);
            var deletedItemsCount = Manager.Save();

            return Ok("Deleted: " + deletedItemsCount);
        }
    }
}