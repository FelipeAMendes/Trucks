using Mendes.Trucks.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Mendes.Trucks.Domain.Interfaces.Services
{
	public interface ITokenService
	{
		string Generate(User user);
		JwtSecurityToken Validate(string token);
	}
}
