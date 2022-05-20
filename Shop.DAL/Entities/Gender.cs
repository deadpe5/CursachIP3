using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GenderName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
