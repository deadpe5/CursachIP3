using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.BLL.DTO;
using Shop.BLL.Exceptions;
using Shop.BLL.JWT;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly IConfiguration configuration;
        public AdminService(ShopDbContext _context, IMapper _mapper, IConfiguration _configuration)
            : base(_context, _mapper)
        {
            configuration = _configuration;
        }
        public async Task CreateSupplier(newSupplierDTO supplierDTO)
        {
            if (await _context.Suppliers
                .AnyAsync(s => s.Email == supplierDTO.Email))
            {
                throw new UserAlreadyExistException("Supplier with same Email already exist.");
            }

            if (await _context.Suppliers
                .AnyAsync(s => s.Phone == supplierDTO.Phone))
            {
                throw new UserAlreadyExistException("Supplier with same phone number already exist.");
            }

            var supplierEntity = _mapper.Map<Supplier>(supplierDTO);
            await _context.Suppliers.AddAsync(supplierEntity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSupplier(string supplierEmail)
        {
            var supplierEntity = await _context.Suppliers.FirstOrDefaultAsync(s => s.Email == supplierEmail);
            if (supplierEntity == null)
            {
                throw new NotFoundException("Supplier with this email was not found");
            }

            _context.Suppliers.Remove(supplierEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SupplierDTO>> GetAllSuppliersList()
        {
            var suppliers = _mapper.Map<List<SupplierDTO>>(
                await _context.Suppliers
                .ToListAsync());
            return suppliers;
        }

        public CompanyInfoDTO GetCompanyInfo()
        {
            var ModeratorsCount = _context.Users.Where(u => u.Role.RoleName == "Moderator").Count();
            var ClientCount = _context.Users.Where(u => u.Role.RoleName == "Client").Count();
            var OrdersCount = _context.Orders.Count();
            var GoodsCount = _context.Goods.Count();
            var SuppliersCount = _context.Suppliers.Count();
            var Revenue = _context.Orders.Sum(o => o.Goods.Price);

            return new CompanyInfoDTO
            {
                ModeratorsCount = ModeratorsCount,
                ClientsCount = ClientCount,
                OrdersCount = OrdersCount,
                SuppliersCount = SuppliersCount,
                GoodsCount = GoodsCount,
                Revenue = Revenue
            };
        }

        public async Task<List<SupplierDTO>> GetSuppliersByName(string supplierName)
        {
            var suppliers = _mapper.Map<List<SupplierDTO>>(
                await _context.Suppliers
                .Where(s => s.Name.StartsWith(supplierName))
                .ToListAsync());
            return suppliers;
        }

        public async Task UpdateSupplier(SupplierDTO supplierDTO)
        {
            var supplierEntity = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierDTO.Id);
            if (supplierEntity == null)
            {
                throw new NotFoundException($"Supplier with {supplierDTO.Id} ID was not found");
            }

            if (await _context.Suppliers
                .AnyAsync(s => s.Email == supplierDTO.Email && s.Id != supplierDTO.Id))
            {
                throw new UserAlreadyExistException("Supplier with same Email already exist.");
            }

            if (await _context.Suppliers
                .AnyAsync(s => s.Phone == supplierDTO.Phone && s.Id != supplierDTO.Id))
            {
                throw new UserAlreadyExistException("Supplier with same phone number already exist.");
            }

            supplierEntity.Name = supplierDTO.Name;
            supplierEntity.Email = supplierDTO.Email;
            supplierEntity.Phone = supplierDTO.Phone;
            supplierEntity.PostalCode = supplierDTO.PostalCode;
            supplierEntity.Country = supplierDTO.Country;
            supplierEntity.City = supplierDTO.City;
            supplierEntity.Street = supplierDTO.Street;
            supplierEntity.HouseNumber = supplierDTO.HouseNumber;
            await _context.SaveChangesAsync();
        }


    }
}
