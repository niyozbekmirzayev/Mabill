using Mabill.Domain.Entities.Staffs;
using Mabill.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mabill.Service.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration config;

        public AuthService(IConfiguration config) => this.config = config;

        public string GenerateToken(Staff staff)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", staff.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, staff.Username),
                new Claim(ClaimTypes.Email, staff.Email),
                new Claim(ClaimTypes.MobilePhone, staff.PhoneNumber),
                new Claim(ClaimTypes.Role, staff.Role.ToString()),
                new Claim("FirstName", staff.FirstName),
                new Claim("LastName", staff.LastName),
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
