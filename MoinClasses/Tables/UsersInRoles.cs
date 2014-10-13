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
    [Table("UsersInRoles")]
    [DataContract]
    public class UsersInRoles : MoinClassesBase
    {
        [MaxLength(36)]
        [DataMember]
        public override string ID { get; set; }

        [MaxLength(36)]
        [DataMember]
        public string UsersID { get; set; }

        [MaxLength(36)]
        [DataMember]
        public string RolesID { get; set; }

        [ForeignKey("UsersID")]
        public Users User { get; set; }

        [ForeignKey("RolesID")]
        public Roles Role { get; set; }
    }
}
