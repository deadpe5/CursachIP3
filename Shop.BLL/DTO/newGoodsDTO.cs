using Shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class NewGoodsDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Manufactured { get; set; }
        public double Diagonal { get; set; }
        public int CoreCount { get; set; }
        public int RAMSize { get; set; }
        public int ROMSize { get; set; }
        public int SupplierId { get; set; }
        public GoodsStatusEnum GoodsStatus { get; set; }
        public GoodsTypeEnum GoodsType { get; set; }
    }
}
