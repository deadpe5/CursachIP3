using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class WareStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StatusName { get; set; }
        public virtual ICollection<Ware> Wares { get; set; }
    }
}
