using Newtonsoft.Json;

namespace Simple.Treavor.Domain.Model
{
  public class Error
  {
    public int StatusCode { get; set; } 
    public string Message { get; set; }
    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}
