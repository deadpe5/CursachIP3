using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class CPU
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public int TDP { get; set; }
        [Required]
        public int CoreCount { get; set; }
        public int WareId { get; set; }
        [ForeignKey("WareId")]
        public virtual Ware Ware { get; set; }
    }
}
