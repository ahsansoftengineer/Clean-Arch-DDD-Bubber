﻿using Donation.Domain.Common.Models;

namespace Donation.Domain.Menu.ValueObjects
{
  public sealed class MenuSectionId : ValueObject
  {
    public Guid Value { get; }

    private MenuSectionId(Guid value)
    {
      Value = value;
    }
    public static MenuSectionId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static MenuSectionId Create(Guid value)
    {
      return new MenuSectionId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
