using DataAbstraction;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseModel
    {
        protected readonly DbSet<TEntity> _entities;
        private readonly BookStoreContext _bookStoreContext;

        public BaseRepository(BookStoreContext dbContex)
        {
            _bookStoreContext = dbContex;
            _entities = _bookStoreContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public TEntity GetById(int id)
        {
            return _entities.SingleOrDefault(x=>x.Id==id);
        }

        public void Save(TEntity record)
        {
            _entities.Add(record);
        }

        public void Update(TEntity record)
        {
            var local = _bookStoreContext.Set<TEntity>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(record.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _bookStoreContext.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _bookStoreContext.Entry(record).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _entities.SingleOrDefault(x => x.Id == id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public int SaveChanges()
        {
            return _bookStoreContext.SaveChanges();
        }
    }
}
