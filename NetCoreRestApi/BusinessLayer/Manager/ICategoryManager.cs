using BusinessLayer.Models;
using System.Linq;

namespace BusinessLayer.Manager
{
    public interface ICategoryManager
    {
        IQueryable<CategoryModel> GetAll();
    }
}
