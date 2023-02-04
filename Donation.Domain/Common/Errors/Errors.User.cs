using ErrorOr;

namespace Donation.Domain.Common.Errors
{
  public static partial class User
  {
    public static Error DuplicateEmail => Error.Conflict(
      code: "User.DuplicateEmail",
      description: "ErrorOr : Domain : Email already exists"
      );
  }
}
