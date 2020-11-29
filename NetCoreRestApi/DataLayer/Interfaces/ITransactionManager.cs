using DataLayer.Models;

namespace DataLayer.interfaces
{
    public interface ITransactionManager
    {
        void Commit();
        void Rollback();
    }
}