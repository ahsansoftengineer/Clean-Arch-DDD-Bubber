using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers
{
  [Route("api/[controller]")]
  //[Authorize] // We can also this to Api Controller so it will be Added to all of our Controller
  public class DinnersController : ApiController
  {
    [HttpGet]
    public IActionResult ListDinners()
    {
      return Ok(Array.Empty<string>());
    }
  }
}
