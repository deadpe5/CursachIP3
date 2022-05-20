using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderMember> OrderMembers { get; set; }
        public virtual ICollection<OrderWare> OrderWares { get; set; }
    }
}
