using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace webapidapper.Data
{
    public abstract class RepositoryBase
    {
        private string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Server=10.0.75.1,1433;Database=master;User=sa;Password=P@ssw0rd;"; //docker image account
            //_connectionString = @"Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;"; //localhost
        }

        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}
