using Shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Shop.BLL.DTO
{
    public class FilterDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("goodsstatus")]
        public GoodsStatusEnum GoodsStatus { get; set; }
        [JsonPropertyName("goodstype")]
        public GoodsTypeEnum GoodsType { get; set; }

    }
}
