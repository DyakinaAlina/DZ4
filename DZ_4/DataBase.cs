using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DZ_4
{
    public class DataBase : IDisposable
    {
        string _connectionString = (@"Data Source = 5A8B\SQLEXPRESS; Initial Catalog = Alina1; Integrated Security = True");
        SqlConnection _connection;

        public DataBase()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            var reader = new SqlCommand(sql, _connection).ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public void ExecuteSqlNonQuery(string sql)
        {
            new SqlCommand(sql, _connection).ExecuteNonQuery();
        }

        public void Dispose()
        {
            CloseConnection();
        }

    }
}