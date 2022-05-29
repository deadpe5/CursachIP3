using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Enums;

namespace Shop.BLL.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public int GoodsId { get; set; }
        public int UserId { get; set; }
    }
}
