using CleanCrud.Application.Repositories;
using CleanCrud.Application.Services;
using CleanCrud.Domain.Entities.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Infrastructure.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public JwtTokenService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string?> GenerateToken(ApplicationUser user)
        {
            if (user == null)
                return null;

            var claimes = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var userRoles = await _userRepository.GetUserRolesAsync(user);

            if (userRoles.Any())
            {
                claimes.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));
            }

            var la = _configuration.GetValue<string>("Token:Key");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Token:Key")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Token:Issuer"),
                audience: _configuration.GetValue<string>("Token:Audience"),
                claims: claimes,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
