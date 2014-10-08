﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MoinClasses.Tables
{
    [Table("Customers")]
    [DataContract]
    public class Customers : MoinClassesBase
    {
        [DataMember]    
        public override string ID { get; set; }

        [MaxLength(256)]
        [DataMember]
        public string Name { get; set; }
    }
}
