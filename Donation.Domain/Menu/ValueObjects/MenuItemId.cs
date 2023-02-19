﻿using Donation.Domain.Common.Models;

namespace Donation.Domain.Menu.ValueObjects
{
  public sealed class MenuItemId : ValueObject
  {
    public Guid Value { get; }
    private MenuItemId(Guid value) 
    {
      Value = value;
    }
    public static MenuItemId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}