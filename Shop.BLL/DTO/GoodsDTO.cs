using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Enums;

namespace Shop.BLL.DTO
{
    public class GoodsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Manufactured { get; set; }
        public double Diagonal { get; set; }
        public int CoreCount { get; set; }
        public int RAMSize { get; set; }
        public int ROMSize { get; set; }
        public SupplierDTO Supplier { get; set; }
        public GoodsStatusEnum GoodsStatus { get; set; }
        public GoodsTypeEnum GoodsType { get; set; }
    }
}
