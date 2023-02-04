using FluentResults;

namespace Donation.Application.Common.Errors
{
  // Old Example
  //public record struct DuplicationEmailError : IErrors
  //{
  //  public HttpStatusCode StatusCode  => HttpStatusCode.Conflict;
  //  public string ErrorMessage => "DuplicationEmailError : IErrors : Email already Exists";
  //}

  public class DuplicationEmailError : IError
  {
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
  }
}


