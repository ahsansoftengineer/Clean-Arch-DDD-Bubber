using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple.Treavor.Infrastructure.Data;

namespace Simple.Treavor.Infrastructure.Configuration
{
  public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
  {
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
      builder.HasData(
         new Hotel
         {
           Id = 1,
           Name = "Shinwari",
           Address = "Karachi",
           Rating = 4.5f,
           CountryId = 1,
         },
          new Hotel
          {
            Id = 2,
            Name = "Aflaton",
            Address = "Islamabad",
            Rating = 3.5d,
            CountryId = 1,
          },
          new Hotel
          {
            Id = 3,
            Name = "Mumbai",
            Address = "Karachi",
            Rating = 4.5f,
            CountryId = 1,
          },
          new Hotel
          {
            Id = 4,
            Name = "Bisbine",
            Address = "Karachi",
            Rating = 2.5d,
            CountryId = 3,
          },
          new Hotel
          {
            Id = 5,
            Name = "Pasta",
            Address = "Aurgentinia",
            Rating = 2.5d,
            CountryId = 3,
          }
        );
    }
  }
}
