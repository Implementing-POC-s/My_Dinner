using System.IdentityModel.Tokens.Jwt;
using Dinner.Application.Common.Interfaces.Authentication;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Dinner.Application.Common.Interfaces.Services;
using Dinner.Domain.Entities;

namespace Dinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super-secret-key-my-key-is-16-byt")),//it should be of 16 bytes
                SecurityAlgorithms.HmacSha256);
            var claims = new[]


      {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
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


