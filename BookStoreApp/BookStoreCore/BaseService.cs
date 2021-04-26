using CoreAbstraction;
using DataAbstraction;
using Model;
using System;
using System.Collections.Generic;

namespace Core
{
    public class BaseService<TEntity, TRepository> :IBaseService<TEntity>
        where TEntity : IBaseModel
        where TRepository : IBaseRepository<TEntity>
    {
        TRepository _repository;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual int Save(TEntity record)
        {
            record.CreatedBy = 1;
            record.CreatedDate = DateTime.Now;
             _repository.Save(record);
            return _repository.SaveChanges();
        }
        public virtual int Update(TEntity record)
        {
            record.ModifiedBy = 1;
            record.ModifiedDate = DateTime.Now;
            _repository.Update(record);
            return _repository.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            _repository.Delete(id);
            return _repository.SaveChanges();
        }
    }
}
