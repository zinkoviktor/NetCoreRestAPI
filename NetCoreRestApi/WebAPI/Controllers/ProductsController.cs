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
            
            if (!productsDTO.Any())
            {
                return NotFound("Products not found");
            }

            return Ok(productsDTO);
        }

        [HttpPost]
        public IActionResult Create(IEnumerable<ProductDto> productDtos)
        {
            var productModels = Converter.ConvertTo(productDtos);
            var createdModels = Manager.Create(productModels);
            var createdProducts = Converter.ConvertFrom(createdModels.ToList());

            if (!createdProducts.Any())
            {
                return BadRequest("Products not created!");
            }

            return Created(nameof(Create), new { createdProducts = createdProducts.ToArray() });
        }

        [HttpPut]
        public IActionResult Update(IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            var result = Manager.Update(productModels);

            if (!result)
            {
                return BadRequest("Categories not created!");
            }

            return Ok("Successfully updated!!!");
        }

        [HttpDelete]
        public IActionResult Delete(IEnumerable<ProductDto> products)
        {
            var productModels = Converter.ConvertTo(products);
            var result = Manager.Delete(productModels);

            if (!result)
            {
                return BadRequest("Categories not created!");
            }

            return Ok("Successfully deleted!!!");
        }
    }
}