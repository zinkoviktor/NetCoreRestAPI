using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class ProductManager : IProductManager
    {
        public IEnumerable<ProductModel> GetAll()
        {
            var productModels = new List<ProductModel>();
            productModels.Add(new StubProductModel("first product"));
            productModels.Add(new StubProductModel("second product"));
            productModels.Add(new StubProductModel("third product"));           
            return productModels;
        }        
    }
}