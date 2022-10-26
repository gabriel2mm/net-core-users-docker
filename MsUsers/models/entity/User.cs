using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MsUsers.models.entity
{
    [Table("tb_users")]
    public class User
    {
        [Key]
        public long Id { get; private set;}
        public String Email { get; set;}
        public String Password { get; set; }
    }
}