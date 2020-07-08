using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Contracts;
using Inide.WebServices.Persistence.Domain;
using Microsoft.Extensions.Configuration;

namespace Inide.WebServices.Persistence.Repository
{
    
    public class UserRepository: DbFactoryBase,IUserRepository
    {
        private const string Schema = "[Admon]";
        private const string Table = "[Users]";
        private const string PrimaryKey = "UserId";
        public string sqlGetUser { get; } =  $@"SELECT {UserDefinition.FieldsList()} FROM {Schema}.{Table} WHERE UserName = @userName And IsActive=1";
        
        public UserRepository(IConfiguration config) : base(config)
        {
            
        }

        public async Task<UserDefinition> GetUserAsync(string userName)
        {
            return await DbQuerySingleAsync<UserDefinition>(sqlGetUser, new { userName });
        }

    }
}
