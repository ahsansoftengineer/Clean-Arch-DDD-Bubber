﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Simple.Treavor.Domain.Model
{
  public class LoginDTO
  {
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(7, ErrorMessage = "Your Password is limited to {1} characters")]
    [MaxLength(15, ErrorMessage = "Your Password is limited to {1} characters")]
    [PasswordPropertyText]
    public string Password { get; set; }
  }
  public class UserDTO : LoginDTO
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    public ICollection<string> Roles { get; set; }
   
  }
}
