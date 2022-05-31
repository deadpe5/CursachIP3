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
        Task CreateGoods(NewGoodsDTO goods);
        Task DeleteGoods(int goodsId);
        Task UpdateGoods(UpdatedGoodsDTO goods);
        Task<List<GoodsDTO>> GetAllGoodsList();
        Task<List<GoodsDTO>> GetGoodsByFilter(FilterDTO filter);
    }
}
