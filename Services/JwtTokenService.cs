
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreApi_JWT.Models;
using Microsoft.IdentityModel.Tokens;

namespace CoreApi_JWT.Services
{
    public class JwtTokenService
    {
        private readonly JwtTokenSettings _tokenSettings;


        public JwtTokenService(JwtTokenSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }


        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }),
                SigningCredentials = _tokenSettings.SigningCredentials,
                Audience = _tokenSettings.Audience,
                Issuer = _tokenSettings.Issuer,
                Expires = DateTime.UtcNow.AddSeconds(_tokenSettings.ExpiredSeconds)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
       
    }
}
