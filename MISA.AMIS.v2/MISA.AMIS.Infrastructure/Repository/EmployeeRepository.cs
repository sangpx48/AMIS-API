using Dapper;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure
{

    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT EmployeeCode FROM employee WHERE EmployeeCode = @EmployeeCode";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", employeeCode);
                var res = _mySqlConnection.QueryFirstOrDefault(sql: sqlQuery, param: parameters);
                if (res == null)
                {
                    return false;
                }
                return true;
            }
        }

        public object GetPaging(int pageIndex, int pageSize, string? filter = "")
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = "Proc_employee_GetEmployeePaging";
                var parameters = new DynamicParameters();
                parameters.Add("@m_Filter", filter);
                parameters.Add("@m_PageIndex", pageIndex);
                parameters.Add("@m_PageSize", pageSize);
                parameters.Add("@m_TotalRecord", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@m_RecordStart", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@m_RecordEnd", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@m_TotalPage", direction: System.Data.ParameterDirection.Output);

                var res = _mySqlConnection.Query<Employee>(sql: sqlQuery, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                int totalRecord = parameters.Get<int>("@m_TotalRecord");
                int recordStart = parameters.Get<int>("@m_RecordStart");
                int recordEnd = parameters.Get<int>("@m_RecordEnd");
                int totalPage = parameters.Get<int>("@m_TotalPage");
                return new
                {
                    TotalRecord = totalRecord,
                    RecordStart = recordStart,
                    RecordEnd = recordEnd,
                    TotalPage = totalPage,
                    Data = res
                };
            }
        }

        public string GetNewEmployeeCode()
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = "Proc_employee_GetNewCode";
                var res = _mySqlConnection.QueryFirst<string>(sql: sqlQuery, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        public int DeleteMultiple(string EmployeeID)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                string[] EmployeeIdArrays = EmployeeID.Split(',');
                int EmployeeIdString = 1;
                for (int i = 0; i < EmployeeIdArrays.Length; i++)
                {
                    var sqlQuery = $"DELETE FROM employee WHERE EmployeeID = ('{EmployeeIdArrays[i]}')";
                    var parameters = new DynamicParameters();
                    _mySqlConnection.Execute(sql: sqlQuery, param: parameters);
                }
                return EmployeeIdString;
            }
        }
    }
}
