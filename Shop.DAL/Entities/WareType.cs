﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class WareType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
        public virtual ICollection<Ware> Wares { get; set; }
    }
}
