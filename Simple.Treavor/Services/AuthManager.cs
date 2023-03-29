using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Simple.Treavor.Domain.Model;
using Simple.Treavor.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Simple.Treavor.Services
{
  public class AuthManager : IAuthManager
  {
    public UserManager<ApiUser> UserManager { get; }
    public IConfiguration Configuration { get; }
    private ApiUser user;
    public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
    {
      UserManager = userManager;
      Configuration = configuration;
    }



    public async Task<string> CreateToken()
    {
      var signInCreadential = GetSignInCreadential();
      var claims = await GetClaims();
      var token = GenerateTokenOptions(signInCreadential, claims);
      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signInCreadential, List<Claim> claims)
    {
      var jwtSettings = Configuration.GetSection("Jwt");
      var expiration = DateTime.Now.AddMinutes(
        Convert.ToDouble(jwtSettings.GetSection("lifetime").Value
        ));
      var token = new JwtSecurityToken(
        issuer: jwtSettings.GetSection("validIssuer").Value,
        claims: claims,
        expires: expiration,
        signingCredentials: signInCreadential
        ) ;
      return token;
    }

    private async Task<List<Claim>> GetClaims()
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.UserName)
      };
      var roles = await UserManager.GetRolesAsync(user);

      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }
      return claims;
    }
    private SigningCredentials GetSignInCreadential()
    {
      var key = Environment.GetEnvironmentVariable("KEY");
      var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

      return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    public async Task<bool> ValidateUser(LoginDTO data)
    {
      user = await UserManager.FindByNameAsync(data.Email);
      return (user != null) && await UserManager.CheckPasswordAsync(user, data.Password);
    }
  }
}
