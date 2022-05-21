using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Context;
using AutoMapper;

namespace Shop.BLL.Services
{
    public class BaseService
    {
        private protected readonly ShopDbContext _context;
        private protected readonly IMapper _mapper;

        public BaseService(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
