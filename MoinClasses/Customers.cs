using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoinClasses
{
    [Table("Customers")]
    public class Customers : MoinClassesBase
    {
        public override string RID { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }
    }
}
