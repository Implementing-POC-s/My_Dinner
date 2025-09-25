using System.IdentityModel.Tokens.Jwt;
using Dinner.Application.Common.Interfaces.Authentication;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using Dinner.Application.Common.Interfaces.Services;

namespace Dinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public string GenerateToken(string userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super-secret-key")),
                SecurityAlgorithms.HmacSha256);
            var claims = new[]


      {
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, firstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };
            var securityToken = new JwtSecurityToken(
                issuer: "Dinner",
                expires: _dateTimeProvider.UtcNow.AddMinutes(60),
                claims: claims,
                signingCredentials: signingCredentials
                );

                
            
            return new JwtSecurityTokenHandler().WriteToken(securityToken);


        }
    } }


