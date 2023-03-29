using Simple.Treavor.Domain.Model;

namespace Simple.Treavor.Services
{
  public interface IAuthManager
  {
    Task<bool> ValidateUser(LoginDTO data);
    Task<string> CreateToken();
  }
}
