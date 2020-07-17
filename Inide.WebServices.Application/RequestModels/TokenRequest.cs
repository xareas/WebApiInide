using System;
using System.Collections.Generic;
using System.Text;

namespace Inide.WebServices.Application.RequestModels
{
    public class TokenRequest
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
