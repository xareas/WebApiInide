using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Infrastructure.Helpers;

namespace Inide.WebServices.Contracts
{
    /// <summary>
    /// Interface que debe cumplir para la escritura de log en la base de datos
    /// </summary>
    public interface ILogWriter
    {
           void WriteBulk(List<LogRecord> logs, object lockObject, ref bool flushingInProgress);
           void WriteLog(LogRecord log);
    }
}
