using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TechnicalTest.Core.Dto;
using TechnicalTest.Core.Model;

namespace TechnicalTest.Service.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("tokenManagement");
        }

        public JwtTokenDto GenerateToken(tUsers usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.GetSection("secret").Value);
            var date = double.Parse(_jwtSettings.GetSection("accessExpiration").Value);
            var expDate = DateTime.UtcNow.AddSeconds(date);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.txt_user),
                }),
                Expires = expDate,             
                Audience = _jwtSettings.GetSection("audience").Value,
                Issuer = _jwtSettings.GetSection("issuer").Value,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtTokenDto()
            {
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = expDate
            };
        }

    }
}
