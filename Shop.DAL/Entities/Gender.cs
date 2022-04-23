﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
