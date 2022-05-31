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
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ShopDbContext _context, IMapper _mapper)
            : base(_context, _mapper)
        {
        }

        public async Task CreateOrder(NewOrderDTO orderDTO)
        {
            var orderEntity = _mapper.Map<Order>(orderDTO);
            orderEntity.OrderDate = DateTime.Today;
            orderEntity.OrderStatusId = (int)OrderStatusEnum.InProgress;
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDTO>> GetOrders()
        {
            var orders = _mapper.Map<List<OrderDTO>>(await _context.Orders.ToListAsync());

            return orders;
        }

        public async Task<List<OrderDTO>> GetUserOrders(int userId)
        {
            if (!(await _context.Users.AnyAsync(x => x.Id == userId)))
            {
                throw new NotFoundException($"User with {userId} ID was not found.");
            }

            var orders = _mapper.Map<List<OrderDTO>>(
                await _context.Orders
                .Where(x=> x.User.Id == userId)
                .ToListAsync()
                );

            return orders;
        }

        public async Task UpdateOrderStatus(NewOrderStatusDTO orderStatusDTO)
        {
            var orderEntity = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderStatusDTO.OrderId);
            if (orderEntity == null)
            {
                throw new NotFoundException($"Order with {orderEntity.Id} ID was not found.");
            }

            orderEntity.OrderStatusId = (int)orderStatusDTO.NewOrderStatus;
            await _context.SaveChangesAsync();
        }
    }
}
