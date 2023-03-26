using Microsoft.AspNetCore.Identity;

namespace Simple.Treavor.Infrastructure.Data
{
  public class ApiUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
