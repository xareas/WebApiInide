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
using Entity = Inide.WebServices.Persistence.Domain.UserDefinition;

namespace Inide.WebServices.Persistence.Repository
{
    
    public class UserRepository: Repository<Entity>, IUserRepository<Entity>
    {
        private static Entity.RowFields Fields =>Entity.Fields;
        private readonly IDbConnection _connection;
        private const int UserFound = 0;
        public UserRepository(IDbConnection connection)
        {
            
            _connection = connection;
            
        }
        
        public async Task<Entity> GetUserAsync(string userName)
        {
            //Request de Filtrado
            var requestList = new ListRequest
            {
                EqualityFilter = new Dictionary<string, object> {{UserDefinition.Fields.UserName.Name, userName}}
            };
            
            var users = await ListAsync(_connection, requestList);
            return users.TotalCount == 0 ? null : users.Entities[UserFound];
        }
    }
}
