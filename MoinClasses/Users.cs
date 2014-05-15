using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MoinClasses
{
    [Table("Users")]
    public class Users : MoinClassesBase
    {
        public override string RID { get; set; }

        [MaxLength(36)]
        [DataMember]
        string RCustomer;

        [MaxLength(256)]
        [DataMember]
        public string Username { get; set; }

        [MaxLength(256)]
        [DataMember]
        public string PasswordHash { get; set; }
    }
}
