using DataLayer.Models;
using System.Linq;

namespace BusinessLayer.Managers
{
    public interface IProductManager
    {
        IQueryable<ProductModel> GetAll();
    }
}