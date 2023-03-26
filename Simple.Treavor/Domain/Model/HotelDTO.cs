using System.ComponentModel.DataAnnotations;

namespace Simple.Treavor.Domain.Model
{
  public class HotelDto : CreateHotelDTO
  {
    public int id { get; set; }
    [Required]
    public int CountryId { get; set; }
  }
  public class CreateHotelDTO
  {
    [Required]
    [StringLength(maximumLength: 150, ErrorMessage = "Hotel Name is too long")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength: 250, ErrorMessage = "Hotel Address is too long")]
    public string Address { get; set; }
    [Range(1,5)]
    public double Rating { get; set; }
    public CountryDTO Country { get; set; } 

  }
}
