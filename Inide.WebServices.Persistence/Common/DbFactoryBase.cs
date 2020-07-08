using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using static Dapper.SqlMapper;

namespace Inide.WebServices.Persistence.Common
{
    public abstract class DbFactoryBase
    {
       
         private readonly IConfiguration _config;
       
        private  string DbConnectionString => _config.GetConnectionString(ConfigPersistence.DefaultDb);
        private IDbConnection DbConnection => new SqlConnection(DbConnectionString);

        public DbFactoryBase(IConfiguration config)
        {
            _config = config;
            
        }

      
        public virtual async Task<IEnumerable<T>> DbQueryAsync<T>(string sql, object parameters = null)
        {
            using IDbConnection dbCon = DbConnection;
            return parameters == null ? await dbCon.QueryAsync<T>(sql) : await dbCon.QueryAsync<T>(sql, parameters);
        }
        public virtual async Task<T> DbQuerySingleAsync<T>(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    return await dbCon.QueryFirstOrDefaultAsync<T>(sql, parameters);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public virtual async Task<bool> DbExecuteAsync<T>(string sql, object parameters)
        {
            using IDbConnection dbCon = DbConnection;
            return await dbCon.ExecuteAsync(sql, parameters) > 0;
        }

        public virtual async Task<bool> DbExecuteScalarAsync(string sql, object parameters)
        {
            using IDbConnection dbCon = DbConnection;
            return await dbCon.ExecuteScalarAsync<bool>(sql, parameters);
        }

        public virtual async Task<T> DbExecuteScalarDynamicAsync<T>(string sql, object parameters = null)
        {
            using IDbConnection dbCon = DbConnection;
            return parameters == null ? await dbCon.ExecuteScalarAsync<T>(sql) : await dbCon.ExecuteScalarAsync<T>(sql, parameters);
        }

        public virtual async Task<(IEnumerable<T> Data, TRecordCount RecordCount)> DbQueryMultipleAsync<T, TRecordCount>(string sql, object parameters = null)
        {
            IEnumerable<T> data = null;
            TRecordCount totalRecords = default;

            using (IDbConnection dbCon = DbConnection)
            {
                using GridReader results = await dbCon.QueryMultipleAsync(sql, parameters);
                data = await results.ReadAsync<T>();
                totalRecords = await results.ReadSingleAsync<TRecordCount>();
            }

            return (data, totalRecords);
        }
    }
}
