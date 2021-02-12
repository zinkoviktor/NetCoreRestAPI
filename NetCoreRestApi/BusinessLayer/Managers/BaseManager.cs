using BusinessLayer.Interfaces;
using DataLayer.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Managers
{
    public abstract class BaseManager<TModel, TId> : IManager<TModel>
    {
        private readonly IUnitOfWork<TModel, TId> _unitOfWork;

        protected BaseManager(IUnitOfWork<TModel, TId> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IQueryable<TModel> GetAll(FilterParameters filter = null)
        {
            return _unitOfWork.GetAll(filter);
        }

        public virtual IEnumerable<TModel> Create(IEnumerable<TModel> models)
        {
            var createdModels = _unitOfWork.Create(models);
            _unitOfWork.Save();
            return createdModels;
        }

        public virtual bool Update(IEnumerable<TModel> models)
        {
            _unitOfWork.Update(models);
            return _unitOfWork.Save();
        }

        public virtual bool Delete(IEnumerable<TModel> models)
        {
            _unitOfWork.Delete(models);
            return _unitOfWork.Save();
        }
    }
}
