using System.ComponentModel.DataAnnotations.Schema;

namespace Simple.Treavor.Infrastructure.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
    public class SeedHotel
    {
        public static List<Hotel> Data { get; } = new List<Hotel>
    {
      new Hotel {
        Id= 1,
        Name  ="Shinwari",
        Address = "Karachi",
        Rating = 4.5f,
        CountryId = 1,
      },
       new Hotel {
        Id= 2,
        Name  ="Aflaton",
        Address = "Islamabad",
        Rating = 3.5d,
        CountryId = 1,
      },
      new Hotel {
        Id= 3,
        Name  ="Mumbai",
        Address = "Karachi",
        Rating = 4.5f,
        CountryId = 1,
      },
      new Hotel {
        Id= 4,
        Name  ="Bisbine",
        Address = "Karachi",
        Rating = 2.5d,
        CountryId = 3,
      },
      new Hotel {
        Id= 5,
        Name  ="Pasta",
        Address = "Aurgentinia",
        Rating = 2.5d,
        CountryId = 3,
      }
    };
    }
}
