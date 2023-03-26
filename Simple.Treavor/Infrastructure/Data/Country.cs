namespace Simple.Treavor.Infrastructure.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; } // This Property Nothing to do with db it just if you want to access the Child will be handle through this property

    }
    public class SeedCountry
    {
        public static List<Country> Data { get; } = new List<Country>
    {
      new Country {
        Id = 1,
        Name= "Pakistan",
        ShortName ="PK"
      },
      new Country {
        Id = 2,
        Name= "India",
        ShortName ="IND"
      },
      new Country {
        Id = 3,
        Name= "United State America",
        ShortName ="USA"
      },
      new Country {
        Id = 4,
        Name= "Europe",
        ShortName ="ER"
      }
    };
    }
}
