using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IUserDefinition
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public short IsActive { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int KeyDelegacion { get; set; }
    }
}
