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
    public enum MoinRowState { Unchanged, New, Updated, Deleted };

    [DataContract]
    public abstract class MoinClassesBase
    {
        public MoinClassesBase()
        {
            ID = Guid.NewGuid().ToString();
        }

        [Key]
        [MaxLength(36)]
        [DataMember]
        public virtual string ID { get; set; }

        [NotMapped]
        [DataMember]
        public MoinRowState RowState { get; set; }
    }
}
