using ErrorOr;

namespace Donation.Domain.Common.Errors
{
  public static partial class Authentication
  {
    public static Error InvalidEmail => Error.Validation(
      code: "Auth.InvalidEmail",
      description: "ErrorOr : Domain : Invalid Email"
      );

    public static Error InvalidPassword => Error.Validation(
     code: "Auth.InvalidPassword",
     description: "ErrorOr : Domain : Invalid Password"
     );
  }
}
