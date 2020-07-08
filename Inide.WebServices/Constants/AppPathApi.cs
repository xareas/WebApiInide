using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Constants
{
    public static class AppPathApi
    {
        public const string RouteV1 = "api/v1/";
        public const string RouteV2 = "api/v2/";
    }

    public static class AppWebService
    {
        public const string DefaultDb = "InideSen";
        public const string SettingsApp = "AppSettings";
        public const string SettingsCnn = "ConnectionStrings";
        public const string AllowAllPolicy = "AllowAllPolicy";
        public const string DefaultCulture = "es-NI";

    }

    public static class JwtClaimsApp
    {
        public const string Institucion = nameof(Institucion);
    }

}
