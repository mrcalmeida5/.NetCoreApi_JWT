
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CoreApi_JWT.Models
{
    public class JwtTokenSettings
    {
        public SigningCredentials SigningCredentials { get; private set; }
        public string Issuer { get; }
        public string Audience { get; }
        public int ExpiredSeconds { get; private set; }


        public JwtTokenSettings(IConfiguration configuration)
        {
            var signingKey = configuration["JwtSettings:SigningKey"];
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            Issuer = configuration["JwtSettings:Issuer"];
            Audience = configuration["JwtSettings:Audience"];
            ExpiredSeconds = Convert.ToInt32(configuration["JwtSettings:ValidForSeconds"]);
        }
    }
}