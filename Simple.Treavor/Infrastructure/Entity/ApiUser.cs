using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Simple.Treavor.Infrastructure.Data
{
  public class ApiUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    public List<IdentityRole> Roles { get; set; }
  }
}
