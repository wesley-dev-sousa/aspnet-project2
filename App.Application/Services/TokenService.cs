using App.Common;
using App.Domain.DTO;
using App.Domain.Interfaces.Application;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services {
    public class TokenService : ITokenService {

        public string GenerateToken(PessoaDTO pessoa) {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, "role"),
                    new Claim("EmailUsuario", pessoa.Email),
                    new Claim("IDUsuario", pessoa.Id.ToString())
                })
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
