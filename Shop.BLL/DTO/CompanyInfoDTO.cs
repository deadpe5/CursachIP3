using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class CompanyInfoDTO
    {
        public int ClientsCount { get; set; }
        public int ModeratorsCount { get; set; }
        public int GoodsCount { get; set; }
        public int OrdersCount { get; set; }
        public int Revenue { get; set; }
    }
}
