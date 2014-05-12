using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoinClasses
{
    public enum MoinRowState { New, Updated, Deleted, None };

    public abstract class MoinClassesBase
    {
        [Key]
        [MaxLength(36)]
        public virtual string RID { get; set; }

        [NotMapped]
        public MoinRowState RowState;
    }
}
