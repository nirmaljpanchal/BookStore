using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAbstraction
{
    public interface IBaseRepository<TEntity>
        where TEntity:IBaseModel
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Save(TEntity record);
        void Update(TEntity record);
        void Delete(int id);
        int SaveChanges();
    }
}
