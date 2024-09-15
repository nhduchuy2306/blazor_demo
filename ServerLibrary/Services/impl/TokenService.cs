using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServerLibrary.Services.impl;

public class TokenService : ITokenService
{
    private readonly JwtOptionsDTO _jwtOptionsDTO;

    public TokenService(IOptions<JwtOptionsDTO> jwtOptionsDTO)
    {
        _jwtOptionsDTO = jwtOptionsDTO.Value;
    }

    public string GenerateToken(AccountDTO accountDTO)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptionsDTO.SecretKey ?? "");

        var claims = new List<Claim>
            {
                new Claim("CustomerName", accountDTO.CustomerName ?? ""),
                new Claim("CustomerCode", accountDTO.CustomerCode ?? ""),
                new Claim("RoleId", accountDTO.RoleId.ToString()),
                new Claim(ClaimTypes.Role, accountDTO.RoleName ?? "")
            };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtOptionsDTO.Issuer,
            Audience = _jwtOptionsDTO.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptionsDTO.AccessTokenExpiration),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
