using MISA.AMIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetByID(Guid id);

        int Insert(T entity);

        int Update(T entity);

        int Delete(Guid entityID);

    }
}
