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
        protected readonly IRepository<TModel, TId> _repository;
        protected readonly ITransactionManager _transactionManager;

        public BaseUnitOfWork(ITransactionManager transactionManager, IRepository<TModel, TId> repository)
        {
            _transactionManager = transactionManager;
            _repository = repository;
            
        }

        public virtual TModel GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<TModel> Create(IEnumerable<TModel> models)
        {
            _transactionManager.BeginTransaction();
            return _repository.Create(models);
        }

        public virtual void Delete(IEnumerable<TModel> models)
        {
            _transactionManager.BeginTransaction();
            _repository.Delete(models);
        }

        public virtual void Update(IEnumerable<TModel> models)
        {
            _transactionManager.BeginTransaction();
            _repository.Update(models);
        }

        public virtual int Save()
        {
            try
            {                
                _transactionManager.Commit();
                return 1;
            }
            catch (Exception)
            {
                _transactionManager.Rollback();
            }

            return 0;
        }
    }
}
