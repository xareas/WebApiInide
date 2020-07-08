using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Contracts;

namespace Inide.WebServices.Infrastructure.Helpers
{
     public class SqlServerLogWriter  
    {
        private readonly string _connectionString;

         public SqlServerLogWriter(string connectionString)
        {
            _connectionString = connectionString;
           
        }

         public void WriteLog(ILogRecord log)
         {
             try
             {
                 lock (log)
                 {
                     using (var connection = new SqlConnection(_connectionString))
                     {
                         using (var command = new SqlCommand("[Admon].LogRecordInsert", connection))
                         {
                             connection.Open();
                             command.CommandType = CommandType.StoredProcedure;
                             command.Parameters.AddWithValue("@userSystem", log.UserSystem);
                             command.Parameters.AddWithValue("@nameSystem", log.NameSystem);
                             command.Parameters.AddWithValue("@userName", log.UserName);
                             command.Parameters.AddWithValue("@logTimeStart", log.LogTimeStart);
                             command.Parameters.AddWithValue("@esquema", log.Esquema);
                             command.Parameters.AddWithValue("@ipOrigin", log.IpOrigin);
                             command.Parameters.AddWithValue("@metodo", log.Metodo);
                             command.Parameters.AddWithValue("@ruta", log.Ruta);
                             command.Parameters.AddWithValue("@host", log.Host);
                             command.Parameters.AddWithValue("@queryString", log.QueryString);
                             command.Parameters.AddWithValue("@body", log.Body);
                             command.Parameters.AddWithValue("@response", log.Response);
                             command.Parameters.AddWithValue("@statusResponse", log.ResponseStatus);
                             
                             command.ExecuteNonQuery();
                         }
                     }
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 throw;
             }
         }



    } //fin clase
}
