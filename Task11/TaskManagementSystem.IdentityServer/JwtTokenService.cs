using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.IdentityServer
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IAppSettings _appSettings;

        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string CreateUserToken(User user, string role)
        {
            //this piece of code was taken from tutorial https://www.youtube.com/watch?v=TDY_DtTEkes&t=245s
            List<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.FullName),
                            new Claim(ClaimTypes.Role, role)
                        };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _appSettings.Token));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
