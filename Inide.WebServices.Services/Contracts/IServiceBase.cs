using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Services.Contracts
{
    public interface IServiceBase
    {
        protected IConfiguration Config { get; set; }
        protected ILogger Logger { get; set; }
    }
}
