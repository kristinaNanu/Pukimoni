using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pukimoni.DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Pukimoni.Api.Core
{
    public class JwtManager
    {
        private readonly PukimoniContext _context;
        private readonly JwtSettings _settings;

        public JwtManager(PukimoniContext context, JwtSettings settings)
        {
            _settings = settings;
            _context = context;
        }

        public string GenerateToken(string email, string password)
        {
            var user = _context.Users.Include(x => x.Role).ThenInclude(x => x.RolePermissions).FirstOrDefault(x => x.Email == email && x.Blacklisted == false);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException();
            }


            var actor = new JwtUser
            {
                Id = user.Id,
                PermissionIds = user.Role.RolePermissions.Select(x => x.PermissionId).ToList(),
                Identity = user.Email,
                Email = user.Email
            };

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("Permissions", JsonConvert.SerializeObject(actor.PermissionIds)),
                new Claim("Email", user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
