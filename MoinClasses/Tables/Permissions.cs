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
    [Table("Permissions")]
    [DataContract]
    public class Permissions : MoinClassesBase
    {
        public override string ID { get; set; }

        [MaxLength(36)]
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<PermissionsInRoles> PermissionsInRoles { get; set; }
    }
}
