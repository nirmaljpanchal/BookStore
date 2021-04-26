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
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseModel
    {
        protected readonly DbSet<TEntity> _entities;
        private readonly BookStoreContext _bookStoreContext;

        public BaseRepository(BookStoreContext dbContex)
        {
            _bookStoreContext = dbContex;
            _entities = _bookStoreContext.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(int id)
        {
            return _entities.SingleOrDefault(x=>x.Id==id);
        }

        public virtual void Save(TEntity record)
        {
            _entities.Add(record);
        }

        public virtual void Update(TEntity record)
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

        public virtual void Delete(int id)
        {
            var entity = _entities.SingleOrDefault(x => x.Id == id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public virtual int SaveChanges()
        {
            return _bookStoreContext.SaveChanges();
        }
    }
}
