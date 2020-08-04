using BusinessLayer.Interfaces;
using DataLayer.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Managers
{
    public abstract class BaseManager<TModel, TId> : IManager<TModel>
    {
        private readonly IUnitOfWork<TModel, TId> _unitOfWork;

        public BaseManager(IUnitOfWork<TModel, TId> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return _unitOfWork.GetAll();
        }

        public virtual IEnumerable<TModel> Create(IEnumerable<TModel> models) 
        {
            return _unitOfWork.Create(models);
        }

        public virtual void Update(IEnumerable<TModel> models)
        {
            _unitOfWork.Update(models);
        }

        public virtual void Delete(IEnumerable<TModel> models)
        {
            _unitOfWork.Delete(models);
        }

        public virtual int Save() 
        {
            return _unitOfWork.Save();
        }
    }
}
