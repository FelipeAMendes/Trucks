using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mendes.Trucks.Domain.Services.Users
{
	public class TokenService : ITokenService
	{
		public string Generate(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(MendesTrucksConfiguration.Jwt.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.Cpf),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials =
					new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public JwtSecurityToken Validate(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(MendesTrucksConfiguration.Jwt.Secret);
			tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false,
				ClockSkew = TimeSpan.Zero
			}, out var validatedToken);

			return (JwtSecurityToken) validatedToken;
			//var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
		}
	}
}
