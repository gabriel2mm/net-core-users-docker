using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsUsers.Models.Dtos
{
    public class UserDTO
    {
        public long Id { get; set;}
        public string Name { get; set; }
        public string? SocialSecurity { get; set; }
        public string Password { get; set; }
        public string Email { get; set;}
        public bool EmailVerified { get; set;} = false;
		public bool UserActive { get; set;} = false;

        public UserDTO(string name, string email, string password, bool emailVerified, bool userActive)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.EmailVerified = emailVerified;
            this.UserActive = userActive;
        }
    }
}