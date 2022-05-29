using Shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class newOrderDTO
    {
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public GoodsDTO Goods { get; set; }
        public UserDTO User { get; set; }
    }
}
