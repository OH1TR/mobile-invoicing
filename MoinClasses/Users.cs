using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoinClasses
{
    [Table("Users")]
    public class Users : MoinClassesBase
    {
        public override string RID { get; set; }

        [MaxLength(36)]
        string RCustomer;

        [MaxLength(256)]
        public string Username { get; set; }

        [MaxLength(256)]
        public string PasswordHash { get; set; }
    }
}
