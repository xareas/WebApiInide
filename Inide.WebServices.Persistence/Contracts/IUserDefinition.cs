using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IUserDefinition
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public short? IsActive { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        
        //Personalizacion 
        public long? KeyInstitucion { get; set; }

    }
}
