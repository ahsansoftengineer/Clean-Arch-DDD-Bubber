using Donation.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Domain.Guest.ValueObjects
{
  public sealed class GuestId : ValueObject
  {
    public Guid Value { get; }

    private GuestId(Guid value)
    {
      Value = value;
    }
    public static GuestId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
