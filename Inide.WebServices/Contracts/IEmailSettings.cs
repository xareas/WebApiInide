using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Contracts
{
    public interface IEmailSettings
    {
            public string From { get; set; }
            public string FromName { get; set; }
            public string SmtpServer { get; set; }
            public int Port { get; set; }
            public bool EnableSsl { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
    
    }
}
