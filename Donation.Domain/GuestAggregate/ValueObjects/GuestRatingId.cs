using Donation.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Domain.Guest.ValueObjects
{
  public sealed class GuestRatingId : ValueObject
  {
    public Guid Value { get; }

    private GuestRatingId(Guid value)
    {
      Value = value;
    }
    public static GuestRatingId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
