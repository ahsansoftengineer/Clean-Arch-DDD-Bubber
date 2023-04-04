using ErrorOr;

namespace Donation.Domain.Common.Errors
{
  public static partial class SimpleErrors
  {
    public static Error IdNotFound (string Entity)=> Error.Conflict(
      code: Entity + ".Id",
      description: "ErrorOr : Domain : Id not Found"
    );

    public static Error DataNotFound(string Entity) => Error.Conflict(
      code: Entity + ".Data",
      description: "ErrorOr : Domain : No Data Found"
    );
  }
}
