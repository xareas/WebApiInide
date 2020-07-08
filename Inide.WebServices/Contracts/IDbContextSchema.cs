using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Contracts
{
    public interface IDbContextSchema
    {
        string Schema { get; set; }
    }
}
