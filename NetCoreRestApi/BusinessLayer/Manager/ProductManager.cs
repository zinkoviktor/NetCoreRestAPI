using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class ProductManager : IProductManager
    {
        public IQueryable<ProductModel> GetAll()
        {
            var id = 1;
            var productModels = new List<ProductModel>();
            productModels.Add(new StubProductModel(id, "first product"));
            productModels.Add(new StubProductModel(++id, "second product"));
            productModels.Add(new StubProductModel(++id, "third product"));           
            return productModels.AsQueryable();
        }        
    }
}