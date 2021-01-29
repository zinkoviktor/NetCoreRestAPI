using DataLayer.interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public abstract class BaseUnitOfWork<TModel, TId> : IUnitOfWork<TModel, TId>
        where TModel : BaseModel<TId>
    {
        protected IRepository<TModel, TId> Repository { get; }
        protected ITransactionManager TransactionManager { get; }

        protected BaseUnitOfWork(ITransactionManager transactionManager, IRepository<TModel, TId> repository)
        {
            TransactionManager = transactionManager;
            Repository = repository;
        }

        public virtual TModel GetById(TId id)
        {
            return Repository.GetById(id);
        }

        public virtual IQueryable<TModel> GetAll(FilterParameters filter)
        {
            return Repository.GetAll(filter);
        }

        public virtual IEnumerable<TModel> Create(IEnumerable<TModel> models)
        {
            TransactionManager.BeginTransaction();
            return Repository.Create(models);
        }

        public virtual void Delete(IEnumerable<TModel> models)
        {
            TransactionManager.BeginTransaction();
            Repository.Delete(models);
        }

        public virtual void Update(IEnumerable<TModel> models)
        {
            TransactionManager.BeginTransaction();
            Repository.Update(models);
        }

        public virtual int Save()
        {
            try
            {
                TransactionManager.Commit();
                return 1;
            }
            catch (Exception)
            {
                TransactionManager.Rollback();
            }

            return 0;
        }
    }
}
