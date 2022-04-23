using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderMember> OrderMembers { get; set; }
        public virtual ICollection<OrderWare> OrderWares { get; set; }
    }
}
