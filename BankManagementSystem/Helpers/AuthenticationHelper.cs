using BankManagementSystem.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankManagementSystem.Helpers
{
    public class AuthenticationHelper: IAuthenticationHelper
    {
        private readonly AppSettings _appSettings;

        public AuthenticationHelper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(UserModel userModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, userModel.UserId.ToString()),
                    new Claim(ClaimTypes.UserData, userModel.CompanyName),
                    new Claim(ClaimTypes.UserData, userModel.CompanyNumber),
                    new Claim(ClaimTypes.UserData, userModel.Firstname),
                    new Claim(ClaimTypes.UserData, userModel.Lastname),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string generateToken = tokenHandler.WriteToken(token);

            return generateToken;
        }
    }
}
