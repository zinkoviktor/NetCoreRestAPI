using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class ProductManager : IProductManager
    {
        public IQueryable<ProductModel> GetAll()
        {
            var ID = 1;
            var productModels = new List<ProductModel>();
            productModels.Add(new StubProductModel(ID, "first product"));
            productModels.Add(new StubProductModel(++ID, "second product"));
            productModels.Add(new StubProductModel(++ID, "third product"));           
            return productModels.AsQueryable();
        }        
    }
}