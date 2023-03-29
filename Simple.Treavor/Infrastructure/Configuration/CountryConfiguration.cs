﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple.Treavor.Infrastructure.Data;

namespace Simple.Treavor.Infrastructure.Configuration
{
  public class CountryConfiguration : IEntityTypeConfiguration<Country>
  {
    public void Configure(EntityTypeBuilder<Country> builder)
    {
      builder.HasData(
        new Country
        {
          Id = 1,
          Name = "Pakistan",
          ShortName = "PK"
        },
        new Country
        {
          Id = 2,
          Name = "India",
          ShortName = "IND"
        },
        new Country
        {
          Id = 3,
          Name = "United State America",
          ShortName = "USA"
        },
        new Country
        {
          Id = 4,
          Name = "Europe",
          ShortName = "ER"
        }
      );
    }
  }
}
