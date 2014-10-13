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
    [Table("Roles")]
    [DataContract]
    public class Roles : MoinClassesBase
    {
        [MaxLength(36)]
        [DataMember]
        public override string ID { get; set; }

        [MaxLength(36)]
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
