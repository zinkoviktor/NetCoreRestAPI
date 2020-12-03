using DataLayer.Models;

namespace DataLayer.interfaces
{
    public interface ITransactionManager
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}