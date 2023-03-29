namespace Simple.Treavor.Infrastructure.Data
{
  public class Country
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public virtual IList<Hotel> Hotels { get; set; } // This Property Nothing to do with db it just if you want to access the Child will be handle through this property

  }
}
