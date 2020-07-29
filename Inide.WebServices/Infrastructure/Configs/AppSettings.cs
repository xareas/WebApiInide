using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Infrastructure.Configs
{
    /// <summary>
    /// Se encarga de leer la configuracion del Appsettings.json
    /// </summary>
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int ExpiresMinutes { get; set; }
        public string Culture { get; set; }
        public string CultureUI { get; set; }
        public int KeyMaster { get; set; }

    }
}
