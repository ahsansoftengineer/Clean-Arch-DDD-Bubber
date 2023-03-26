using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple.Treavor.Domain.Model;
using Simple.Treavor.Infrastructure.IRepo;
using System.Collections;

namespace Simple.Treavor.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountryController : ControllerBase
  {
    public IUnitOfWork UnitOfWork { get; }
    public ILogger<CountryController> Logger { get; }
    public IMapper Mapper { get; }

    public CountryController(
      IUnitOfWork unitOfWork,
      ILogger<CountryController> logger,
      IMapper mapper)
    {
      UnitOfWork = unitOfWork;
      Logger = logger;
      Mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Gets()
    {
      try
      {
        var countries = await UnitOfWork.Countries.GetAll();
        var result = Mapper.Map<IList<CountryDTO>>(countries);
        return Ok(result);
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, $"Something went wrong in the {nameof(Gets)}");
        return StatusCode(500, "Internal Server Error, Please try again later");
      }
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        var country = await UnitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels"});
        var result = Mapper.Map<CountryDTO>(country);
        return Ok(result);
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, $"Something went wrong in the {nameof(Get)}");
        return StatusCode(500, "Internal Server Error, Please try again later");
      }
    }

  }
}
