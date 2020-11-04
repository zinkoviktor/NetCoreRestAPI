using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Intefaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public abstract class BaseUnitOfWork<TModel, TId> : IUnitOfWork<TModel, TId>
        where TModel : BaseModel<TId>
    {
        protected readonly IRepository<TModel, TId> _repository;
        protected readonly IUnitOfWorkContext _dbContext;

        public BaseUnitOfWork(IUnitOfWorkContext dbContext, IRepository<TModel, TId> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public virtual TModel GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            var models = _repository.GetAll();
            return models.AsQueryable();
        }

        public virtual IEnumerable<TModel> Create(IEnumerable<TModel> models)
        {
            return _repository.Create(models);
        }

        public virtual void Delete(IEnumerable<TModel> models)
        {
            _repository.Delete(models);
        }

        public virtual void Update(IEnumerable<TModel> models)
        {
            _repository.Update(models);
        }

        public virtual int Save()
        {
            return _dbContext.Save();
        }
    }
}
