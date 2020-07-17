using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Constants
{
   public static class AppConst
    {
        public const string DefaultDb = "InideSen";
        public const string SettingsApp = "AppSettings";
        public const string SettingsCnn = "ConnectionStrings";
        public const string AllowAllPolicy = "AllowAllPolicy";
        public const string DefaultCulture = "es-NI";
        public const string ApiHeader = "api-version";
        public const int CodeInide = 1;
        public static class Claims
        {
            public const string Institucion = nameof(Institucion);
            public static class Roles
            {
                public const string Public = "Public";
                public const string Internal = "Internal";
                public const string PublicOrInternal = "Public,Internal";      
            }
          
        }
    }

   

}
