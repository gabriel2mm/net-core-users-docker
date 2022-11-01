using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MsUsers.models.entity
{
    [Table("tb_users")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public long Id { get; set;}
        public string Name { get; set; }
        public string? SocialSecurity { get; set; }
        [Required]
        public string Email { get; set;}
        [Required]
        public string Password { get; set; }
        public bool EmailVerified { get; set;} = false;
		public bool UserActive { get; set;} = false;

        public User(string name, string email, string password) {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}