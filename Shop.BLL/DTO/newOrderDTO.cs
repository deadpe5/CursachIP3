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
        public int GoodsId { get; set; }
        public int UserId { get; set; }
    }
}
