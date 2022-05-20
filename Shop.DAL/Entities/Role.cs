using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
