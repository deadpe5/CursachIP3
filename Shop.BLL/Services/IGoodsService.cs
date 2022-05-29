using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public interface IGoodsService
    {
        Task CreateGoods(newGoodsDTO goods);
        Task DeleteGoods(int goodsId);
        Task UpdateGoods(GoodsDTO goods);
        Task<List<GoodsDTO>> GetAllGoodsList();
        Task<List<GoodsDTO>> GetGoodsByFilter(FilterDTO filter);
    }
}
