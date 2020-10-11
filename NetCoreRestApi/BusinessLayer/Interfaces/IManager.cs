using System.Linq;

namespace BusinessLayer.Interfaces
{
    public interface IManager<TModel>
    {
        IQueryable<TModel> GetAll();
    }
}
