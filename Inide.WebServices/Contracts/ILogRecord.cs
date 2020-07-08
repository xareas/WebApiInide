using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Contracts
{
     public interface ILogRecord
     {
        public int UserSystem { get; set; }
        public string NameSystem { get; set; }
        public string Metodo { get; set; }
        public string UserName { get; set; }
        public string IpOrigin { get; set; }
        public DateTime LogTimeStart { get; }
        public DateTime LogTimeFinish { get; }
        public string Esquema { get; set; }
        public string Ruta { get; set; }
        public string Host { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }
        public string Response { get; set; }
        public int ResponseStatus { get; set; }



    }
}
