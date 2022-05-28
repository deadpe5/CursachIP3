using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.BLL.DTO;
using Shop.BLL.Exceptions;
using Shop.BLL.JWT;
using Shop.BLL.Utility;
using Shop.DAL.Context;

namespace Shop.BLL.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private protected readonly JwtFactory jwtFactory;
        private readonly IConfiguration configuration;
        public AuthService(ShopDbContext _context, IMapper _mapper, JwtFactory _jwtFactory, IConfiguration _configuration)
            : base(_context, _mapper)
        {
            jwtFactory = _jwtFactory;
            configuration = _configuration;
        }

        public async Task<AuthUserDTO> Authorize(LoginUserDTO userDTO)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == userDTO.Email);

            if (userEntity == null)
            {
                throw new NotFoundException("User does not exist.");
            }

            if (!Util.VerifyPasswordHash(userDTO.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                throw new WrongPasswordException("Wrong password.");
            }

            var token = await jwtFactory.GenerateAccessToken(userEntity.Id, userEntity.Role.RoleName, userEntity.Email);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO 
            { 
                Token = token, 
                User = user 
            };
        }

    }

    

}
