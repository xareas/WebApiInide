using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Contracts;


namespace Inide.WebServices.Persistence.Domain
{
    public class UserDefinition : IUserDefinition
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public short IsActive { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int KeyDelegacion { get; set; }

        public static string FieldsList()
        {
            return @$"{nameof(UserId)},{nameof(Username)},{nameof(DisplayName)},{nameof(Email)},{nameof(Email)},{nameof(IsActive)},{nameof(PasswordHash)},{nameof(PasswordSalt)},{nameof(KeyDelegacion)}";
        }
    }
}
