using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Services
{
    public class UserService : UserRepository,IUserService
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public UserService(IDbConnection connection,IConfiguration config,ILogger<UserService> logger) : base(connection)
        {
            _config = config;
            _logger = logger;
        }

      
       


    }
}
