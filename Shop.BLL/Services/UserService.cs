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

namespace Shop.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private protected readonly JwtFactory jwtFactory;
        private readonly IConfiguration configuration;
        public UserService(ShopDbContext _context, IMapper _mapper, JwtFactory _jwtFactory, IConfiguration _configuration)
            : base(_context, _mapper)
        {
            jwtFactory = _jwtFactory;
            configuration = _configuration;
            
        }

        public async Task<AuthUserDTO> CreateUser(newUserDTO userDTO)
        {
            if (await _context.Users
                .AnyAsync(u => u.Email == userDTO.Email))
            {
                throw new UserAlreadyExistException("User with same Email already exist.");
            }

            if (await _context.Users
                .AnyAsync(u => u.Phone == userDTO.Phone))
            {
                throw new UserAlreadyExistException("User with same phone number already exist.");
            }

            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.RoleId = (int)Enums.Role.Client;
            userEntity.GenderId = (int)userDTO.Gender;

            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            userEntity.PasswordSalt = passwordSalt;
            userEntity.PasswordHash = passwordHash;

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            userEntity = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == userDTO.Email);

            var token = await jwtFactory.GenerateAccessToken(userEntity.Id, userEntity.Role.RoleName, userEntity.Email);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO
            {
                Token = token,
                User = user
            };
        }

        public async Task DeleteUser(string userEmail)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (userEntity == null)
            {
                throw new NotFoundException("User with this email was not found");
            }

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserDTO>> GetAllUsersList()
        {
            var users = _mapper.Map<List<UserDTO>>(
                await _context.Users
                .Where(u => u.RoleId != 1)
                .ToListAsync());
            return users;
        }

        public async Task<List<UserDTO>> GetUsersByName(string userName)
        {
            var users = _mapper.Map<List<UserDTO>>(
                await _context.Users
                .Where(u => u.RoleId != 1 
                && (u.Name.StartsWith(userName) 
                || u.Surname.StartsWith(userName)))
                .ToListAsync());
            return users;
        }

        public async void ToggleRole(string userEmail)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (userEntity == null)
            {
                throw new NotFoundException("User with this email was not found");
            }

            if (userEntity.Role.RoleName == "Administrator")
            {
                throw new AdministratorViolationException("Can change role for Administrator");
            }

            userEntity.RoleId ^= 2;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(UserDTO user)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userEntity == null)
            {
                throw new NotFoundException($"User with {user.Id} ID was not found");
            }

            if (await _context.Users
                .AnyAsync(u => u.Email == user.Email && u.Id != user.Id))
            {
                throw new UserAlreadyExistException("User with same Email already exist.");
            }

            if (await _context.Users
                .AnyAsync(u => u.Phone == user.Phone && u.Id != user.Id))
            {
                throw new UserAlreadyExistException("User with same phone number already exist.");
            }

            userEntity.Name = user.Name;
            userEntity.Surname = user.Surname;
            userEntity.GenderId = (int)user.Gender;
            userEntity.Phone = user.Phone;
            userEntity.Email = user.Email;
            await _context.SaveChangesAsync();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
