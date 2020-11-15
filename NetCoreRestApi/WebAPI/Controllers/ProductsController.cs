using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
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

        [HttpGet]
        public IActionResult Get(int pageIndex, int pageSize)
        {
            var productModels = Manager.GetAll(pageIndex, pageSize);
            var productsDTO = Converter.ConvertFrom(productModels.ToList());

            return Ok(productsDTO);
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
    }
}