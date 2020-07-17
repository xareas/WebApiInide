using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Contracts;
using Inide.WebServices.Persistence.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serenity.Data;
using Serenity.Services;
using MyRow = Inide.WebServices.Persistence.Domain.UserDefinition;

namespace Inide.WebServices.Persistence.Repository
{
    
    public class UserRepository: Repository<MyRow>, IUserRepository<MyRow>
    {
        private static MyRow.RowFields fld =>MyRow.Fields;
        private readonly IDbConnection _connection;
        public UserRepository(IDbConnection connection)
        {
            
            _connection = connection;
            
        }
        
        public async Task<MyRow> GetUserAsync(string userName)
        {
            //Request de Filtrado
            var requestList = new ListRequest
            {
                EqualityFilter = new Dictionary<string, object> {{UserDefinition.Fields.UserName.Name, userName}}
            };
            
            var users = await ListAsync(_connection, requestList);
            return users.TotalCount == 0 ? null : users.Entities[0];
        }
    }
}
