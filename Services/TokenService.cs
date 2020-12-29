using Microsoft.IdentityModel.Tokens;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SCIMServer.Services
{
    public class TokenService : ITokenService
    {
        public BearerToken GenerateToken()
        {
            BearerToken bearerToken = new BearerToken();
            bearerToken.Token = GenerateJSONWebToken();
            return bearerToken;
        }

        private string GenerateJSONWebToken()
        {
            // Create token key
            SymmetricSecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A1B2C3D4E5F6A1B2C3D4E5F6"));
            SigningCredentials credentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Set token expiration
            DateTime startTime = DateTime.UtcNow;
            DateTime expiryTime = startTime.AddMinutes(120);

            // Generate the token
            JwtSecurityToken token =
                new JwtSecurityToken(
                    "Microsoft.Security.Bearer",
                    "Microsoft.Security.Bearer",
                    null,
                    notBefore: startTime,
                    expires: expiryTime,
                    signingCredentials: credentials);

            string result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
