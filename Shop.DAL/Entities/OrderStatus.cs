using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string OrderStatusName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
