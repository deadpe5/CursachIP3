using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.BLL.DTO;
using Shop.BLL.Enums;
using Shop.BLL.Exceptions;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class GoodsService : BaseService, IGoodsService
    {
        public GoodsService(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task CreateGoods(NewGoodsDTO goods)
        {
            var goodsEntity = _mapper.Map<Goods>(goods);
            await _context.Goods.AddAsync(goodsEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGoods(int goodsId)
        {
            var goodsEntity = _context.Goods.FirstOrDefault(x => x.Id == goodsId);
            if (goodsEntity == null)
            {
                throw new NotFoundException($"Goods with {goodsId} ID was not found");
            }

            _context.Goods.Remove(goodsEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GoodsDTO>> GetAllGoodsList()
        {
            var goods = _mapper.Map<List<GoodsDTO>>(
                 await _context.Goods
                 .ToListAsync());
            return goods;
        }

        public async Task<List<GoodsDTO>> GetGoodsByFilter(FilterDTO filter)
        {
            var goods = _mapper.Map<List<GoodsDTO>>(
                await _context.Goods
                .Where(x=> x.Name.StartsWith(filter.Name))
                .ToListAsync());

            if (filter.GoodsStatus != GoodsStatusEnum.All)
            {
                goods = goods.Where(x => x.GoodsStatus == filter.GoodsStatus).ToList();
            }

            if (filter.GoodsType != GoodsTypeEnum.All)
            {
                goods = goods.Where(x => x.GoodsType == filter.GoodsType).ToList();
            }

            return goods;
        }

        public async Task UpdateGoods(UpdatedGoodsDTO goodsDTO)
        {
            var goodsEntity = _context.Goods.FirstOrDefault(x => x.Id == goodsDTO.Id);
            if (goodsEntity == null)
            {
                throw new NotFoundException($"Goods with {goodsDTO.Id} ID was not found");
            }

            goodsEntity.Name = goodsDTO.Name;
            goodsEntity.Price = goodsDTO.Price;
            goodsEntity.Manufactured = goodsDTO.Manufactured;
            goodsEntity.Diagonal = goodsDTO.Diagonal;
            goodsEntity.CoreCount = goodsDTO.CoreCount;
            goodsEntity.RAMSize = goodsDTO.RAMSize;
            goodsEntity.ROMSize = goodsDTO.ROMSize;
            goodsEntity.SupplierId = goodsDTO.SupplierId;
            goodsEntity.GoodsStatusId = (int)goodsDTO.GoodsStatus;
            goodsEntity.GoodsTypeId = (int)goodsDTO.GoodsType;

            await _context.SaveChangesAsync();
        }
    }
}
