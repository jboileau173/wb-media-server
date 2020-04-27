using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WbMediaCore.Repositories;
using WbMediaRepository.Contexts;

namespace WbMediaRepository.Repositories
{
    public abstract class AGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Context _context;
        protected DbSet<T> _table = null;

        public AGenericRepository(Context context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public virtual T Create(T ressource)
        {
            _table.Add(ressource);
            Save();

            _context.Entry(ressource).State = EntityState.Detached;

            return ressource;
        }

        public virtual void DeleteById(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);

            Save();
        }

        public virtual List<T> GetAll()
        {
            return _table.ToList();
        }

        public virtual T GetById(int id)
        {
            return _table.Find(id);
        }

        public virtual T Update(T ressource)
        {
            _table.Update(ressource);
            Save();

            _context.Entry(ressource).State = EntityState.Detached;

            return ressource;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
