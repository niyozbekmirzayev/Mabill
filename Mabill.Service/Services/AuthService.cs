using Mabill.Domain.Entities.Admins;
using Mabill.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Mabill.Service.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration config;

        public AuthService(IConfiguration config) => this.config = config;
        
        public string GenerateToken(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", admin.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, admin.Username),
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim("PhoneNumber", admin.PhoneNumber),
                new Claim(ClaimTypes.Role, admin.Role.ToString()),
                new Claim("FirstName", admin.FirstName),
                new Claim("LastName", admin.LastName),
            };

            var issuer = config.GetSection("JWT:Issuer").Value;
            var audience = config.GetSection("JWT:Audience").Value;
            var key = config.GetSection("JWT:Key").Value;
            var expireTime = config.GetSection("JWT:Expire").Value;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
                                                       expires: DateTime.Now.AddMinutes(double.Parse(expireTime)),
                                                       signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
