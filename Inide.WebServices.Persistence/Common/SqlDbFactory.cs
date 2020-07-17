using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Contracts;
using Serenity;

namespace Inide.WebServices.Persistence.Common
{
    public class SqlDbFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public  IDbConnection Connection { get; set; }

        public SqlDbFactory(string connectionString)
        {
            if(connectionString.IsEmptyOrNull())
                throw new ArgumentException(@"Invalida cadena de conexcion de la base de datos");
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
