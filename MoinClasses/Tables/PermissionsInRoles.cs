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
    [Table("PermissionsInRoles")]
    [DataContract]
    public class PermissionsInRoles : MoinClassesBase
    {
        public override string ID { get; set; }

        [MaxLength(36)]
        [DataMember]
        public string PermissionsID { get; set; }

        [MaxLength(36)]
        [DataMember]
        public string RolesID { get; set; }

        [ForeignKey("PermissionsID")]
        public Permissions Permission { get; set; }

        [ForeignKey("RolesID")]
        public Roles Role { get; set; }
    }
}
