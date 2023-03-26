using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple.Treavor.Domain.Model;
using Simple.Treavor.Infrastructure.IRepo;

namespace Simple.Treavor.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HotelController : ControllerBase
  {
    private ILogger<HotelController> Logger { get; }
    private IMapper Mapper { get; }
    private IUnitOfWork UnitOfWork { get; }
    public HotelController(ILogger<HotelController> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
      Logger = logger;
      Mapper = mapper;
      UnitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Gets()
    {
      try
      {
        var hotels = await UnitOfWork.Hotels.GetAll();
        var result = Mapper.Map<IList<HotelDto>>(hotels);
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
        //, new List<string> { "Country" }
        var hotel = await UnitOfWork.Hotels.Get(q => q.Id == id);
        var result = Mapper.Map<HotelDto>(hotel);
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
