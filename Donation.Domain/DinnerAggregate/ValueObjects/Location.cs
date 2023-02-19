namespace Donation.Domain.Dinner.ValueObjects
{
  public sealed class Location
  {
    public string Name { get; set; }
    public string Address { get; set; } 
    public float Latitude { get; set; }
    public float Longitude { get; set; }
  }
}

/*
"location": {
  "name": "Dan's Pizza Place",
  "address": "Berlin, Germany",
  "latitude": 52.520008,
  "longitude": 13.404954
},
*/