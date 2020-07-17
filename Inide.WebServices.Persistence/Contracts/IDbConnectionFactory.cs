using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IDbConnectionFactory
    {
        IDbConnection Connection { get; set; }
        Task<IDbConnection> CreateConnectionAsync();
    }
}
