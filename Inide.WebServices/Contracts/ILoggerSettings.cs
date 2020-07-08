using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Inide.WebServices.Contracts
{
    /// <summary>
    /// Inteface para la configuracion del Logging
    /// </summary>
    public interface ILoggerSettings
    {
        bool BulkWrite { get; }

        int BulkWriteCacheSize { get; }

        IChangeToken ChangeToken { get; }

        bool IncludeScopes { get; }

        ILoggerSettings Reload();

        bool TryGetSwitch(string category, out LogLevel level);
    }
}
