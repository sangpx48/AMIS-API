using MISA.AMIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        bool CheckEmployeeCodeExist(string employeeCode);

        object GetPaging(int pageIndex, int pageSize, string? filter = "");

        string GetNewEmployeeCode();

        public int DeleteMultiple(string EmployeeID);


    }
}
