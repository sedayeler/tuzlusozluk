using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Services;
using TuzluSozluk.Domain.Entities;

namespace TuzluSozluk.Infrastucture.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(int minute, User user)
        {

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            DateTime expiration = DateTime.UtcNow.AddMinutes(minute);

            JwtSecurityToken token = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) });

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
