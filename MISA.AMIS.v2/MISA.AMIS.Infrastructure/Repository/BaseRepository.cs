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
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected string _connectionString;
        protected MySqlConnection _mySqlConnection;
        protected string TableName;


        public BaseRepository()
        {
            //Khai báo thông tin kết nối
            _connectionString = "Host=localhost;" +
               " Port=3360;" +
               " Database=misa.web10.sangpx;" +
               " User Id=sang;" +
               " Password=123456789";

            TableName = typeof(T).Name;
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {TableName}";
                var res = _mySqlConnection.Query<T>(sqlQuery);
                return res;
            }
        }

        public T GetByID(Guid id)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {TableName} WHERE {TableName}ID = @{TableName}ID";
                var parameters = new DynamicParameters();
                parameters.Add($"@{TableName}ID", id);
                // QueryFirstOrDefault - Lấy bản ghi đầu tiền từ câu lệnh truy vấn,
                // nếu không có dữ liệu thì trả về null
                var res = _mySqlConnection.QueryFirstOrDefault<T>(sql: sqlQuery, param: parameters);
                return res;
            }
        }

        public int Insert(T entity)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = $"Proc_{TableName}_Insert";
                var parameters = new DynamicParameters();
                var res = _mySqlConnection.Execute(sql: sqlQuery, param: entity,
                    commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        public int Update(T entity)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = $"Proc_{TableName}_Update";
                var parameters = new DynamicParameters();
                var res = _mySqlConnection.Execute(sql: sqlQuery, param: entity,
                    commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        public int Delete(Guid entityID)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlQuery = $"DELETE FROM {TableName} WHERE {TableName}ID = @{TableName}ID";
                var parameters = new DynamicParameters();
                parameters.Add($"@{TableName}ID", entityID);
                var res = _mySqlConnection.Execute(sql: sqlQuery, param: parameters);
                return res;
            }
        }

    }
}
