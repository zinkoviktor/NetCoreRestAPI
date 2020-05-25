using BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class ProductManager : IProductManager
    {
        public IQueryable<ProductModel> GetAll()
        {
            var productModels = new List<ProductModel>();
            productModels.Add(new StubProductModel("first product"));
            productModels.Add(new StubProductModel("second product"));
            productModels.Add(new StubProductModel("third product"));           
            return productModels.AsQueryable();
        }        
    }
}