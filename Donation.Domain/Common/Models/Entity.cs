using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Domain.Common.Models
{
  public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
  {
    public TId Id { get; protected set; }
    protected Entity(TId id)
    {
      Id = id;  
    }
    public override bool Equals(object? obj)
    {
      return obj is Entity<TId> entity && Equals((Entity<TId>)obj);
    }
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
      return Equals(left, right);
    }
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
      return !Equals(left, right);
    }
    public override int GetHashCode() 
    { 
      return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
      return Equals((object?)other);
    }
  }
}
