using System;
using DataLayer.Models;

namespace DataLayer.interfaces
{
    public interface ITransactionManager : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}