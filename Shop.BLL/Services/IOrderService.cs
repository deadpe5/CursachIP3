using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.BLL.DTO;
using Shop.BLL.JWT;
using Shop.BLL.Enums;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Exceptions;
using Shop.BLL.Utility;

namespace Shop.BLL.Services
{
    public interface IOrderService
    {
        Task CreateOrder(newOrderDTO orderDTO);
        Task UpdateOrderStatus(NewOrderStatusDTO orderStatusDTO);
        Task<List<OrderDTO>> GetOrders();
    }
}
