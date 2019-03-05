using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TrafficSignalsConfigurator.Web.ViewModels
{
    public class AuthDataViewModel
    {
        public string Token { get;  }
        public long TokenExpirationTime { get; }
        public string UserId { get; }

        public AuthDataViewModel(string jwtSecret, int jwtLifespan, string userId)
        {
            if (string.IsNullOrEmpty(jwtSecret)) throw new ArgumentNullException(nameof(jwtSecret));
            if (jwtLifespan <= 0) throw new ArgumentException($"'{nameof(jwtLifespan)}' cannot be less than 1. Current value {jwtLifespan}");
            if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException(nameof(userId));

            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);
            var token = CreateJwtSecurityToken(jwtSecret, jwtLifespan, userId, expirationTime);

            Token = token;
            TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds();
            UserId = userId;
        }

        private static string CreateJwtSecurityToken(string jwtSecret, int jwtLifespan, string userId, DateTime expirationTime)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userId) }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return token;
        }
    }
}