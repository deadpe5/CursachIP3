using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class OrderWare
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int WareId { get; set; }
        [ForeignKey("WareId")]
        public virtual Ware Ware { get; set; }
    }
}
