using Shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class NewOrderStatusDTO
    {
        public int OrderId { get; set; }
        public OrderStatusEnum NewOrderStatus { get; set; }
    }
}
