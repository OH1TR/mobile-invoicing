using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MoinClasses.Tables
{
    [Table("Users")]
    [DataContract]
    public class Users : MoinClassesBase
    {
        [MaxLength(36)]
        [DataMember]
        public override string ID { get; set; }

        [MaxLength(36)]
        [DataMember]
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }

        [MaxLength(256)]
        [DataMember]
        public string Username { get; set; }

        [MaxLength(256)]
        [DataMember]
        public string PasswordHash { get; set; }

        [IgnoreDataMember]
        public virtual Customers Customer { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
