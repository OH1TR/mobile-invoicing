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
    public enum MoinRowState { New, Updated, Deleted, None };

    [DataContract]
    public abstract class MoinClassesBase
    {
        [Key]
        [MaxLength(36)]
        [DataMember]
        public virtual string RID { get; set; }

        [NotMapped]
        [DataMember]
        public MoinRowState RowState;
    }
}
