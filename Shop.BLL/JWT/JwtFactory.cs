using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Shop.BLL.JWT
{
    public class JwtFactory
    {
        private readonly IConfiguration configuration;
        public JwtFactory(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public async Task<string> GenerateAccessToken(int userId, string Role, string Email)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString(), ClaimValueTypes.UInteger64),
                new Claim(ClaimTypes.Role, Role),
                new Claim(ClaimTypes.Email, Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
