using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAbstraction
{
    public interface IBaseService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        int Save(TEntity record);
        int Update(TEntity record);
        int Delete(int id);
    }
}
