using MISA.AMIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IBaseService<T>
    {
        int InsertService(T entity);

        int UpdateService(T entity);

    }
}
