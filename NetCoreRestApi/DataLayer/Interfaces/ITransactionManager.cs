using System;

namespace DataLayer.interfaces
{
    public interface ITransactionManager : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}