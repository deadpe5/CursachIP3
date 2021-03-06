using AutoMapper;
using Shop.BLL.DTO;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(g => g.Gender, gid => gid.MapFrom(m => m.GenderId))
                .ForMember(r => r.Role, rid => rid.MapFrom(m => m.RoleId))
                .ReverseMap();
            CreateMap<NewUserDTO, User>()
                .ForMember(g => g.GenderId, gid => gid.MapFrom(m => m.Gender))
                .ForMember(g => g.Gender, x => x.Ignore());
            CreateMap<NewSupplierDTO, Supplier>();
            CreateMap<SupplierDTO, Supplier>().ReverseMap();
            CreateMap<GoodsDTO, Goods>()
                .ForMember(s => s.GoodsStatusId, sid => sid.MapFrom(m => m.GoodsStatus))
                .ForMember(s => s.GoodsStatus, x => x.Ignore())
                .ForMember(t => t.GoodsTypeId, tid => tid.MapFrom(m => m.GoodsType))
                .ForMember(t => t.GoodsType, x => x.Ignore())
                .ReverseMap();
            CreateMap<NewGoodsDTO, Goods>()
                .ForMember(s => s.GoodsStatusId, sid => sid.MapFrom(m => m.GoodsStatus))
                .ForMember(s => s.GoodsStatus, x => x.Ignore())
                .ForMember(t => t.GoodsTypeId, tid => tid.MapFrom(m => m.GoodsType))
                .ForMember(t => t.GoodsType, x => x.Ignore());
            CreateMap<OrderDTO, Order>()
                .ForMember(s => s.OrderStatusId, sid => sid.MapFrom(m => m.OrderStatus))
                .ForMember(s => s.OrderStatus, x => x.Ignore())
                .ReverseMap();
            CreateMap<NewOrderDTO, Order>()
                .ForMember(x=>x.GoodsId, y=>y.MapFrom(m=>m.GoodsId))
                .ForMember(x=>x.Goods, y => y.Ignore())
                .ForMember(x=>x.UserId, y=>y.MapFrom(m=>m.UserId))
                .ForMember(x=>x.User, y=>y.Ignore());
        }
    }
}
