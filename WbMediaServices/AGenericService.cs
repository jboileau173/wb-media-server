using System.Collections.Generic;
using WbMediaCore.Repositories;
using WbMediaCore.Services;

namespace WbMediaServices
{
    public abstract class AGenericService<T> : IGenericService<T>
    {
        protected readonly IGenericRepository<T> _repository;

        protected AGenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T Create(T ressource)
        {
            return _repository.Create(ressource);
        }

        public virtual T Update(T ressource)
        {
            return _repository.Update(ressource);
        }

        public virtual void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public virtual void Save()
        {
            _repository.Save();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
