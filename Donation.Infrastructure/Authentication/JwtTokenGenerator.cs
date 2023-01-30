using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Donation.Infrastructure.Authentication
{
  public class JwtTokenGenerator : IJwtTokenGenerator
  {
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly JwtSettings jwtSettings;

    public JwtTokenGenerator(
      IDateTimeProvider dateTimeProvider,
      IOptions<JwtSettings> jwtOptions
      )
    {
      this.dateTimeProvider = dateTimeProvider;
      this.jwtSettings = jwtOptions.Value;
    }
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
      var signingCredentials = new SigningCredentials(
         new SymmetricSecurityKey(
           Encoding.UTF8.GetBytes(jwtSettings.Secret)),
         SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, firstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      };

      var securityToken = new JwtSecurityToken(
        issuer: jwtSettings.Issuer,
        expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
        claims: claims,
        signingCredentials: signingCredentials
        );

      return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
  }
}
