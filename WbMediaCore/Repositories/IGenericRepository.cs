using System.Collections.Generic;

namespace WbMediaCore.Repositories
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T ressource);
        T Update(T ressource);
        void DeleteById(int id);
        void Save();
    }

}
