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
            CreateMap<newUserDTO, User>()
                .ForMember(g => g.GenderId, gid => gid.MapFrom(m => m.Gender))
                .ForMember(g => g.Gender, x => x.Ignore());
            CreateMap<newSupplierDTO, Supplier>();
            CreateMap<SupplierDTO, Supplier>().ReverseMap();
            // CreateMap<List<Supplier>, List<SupplierDTO>>();
        }
    }
}
