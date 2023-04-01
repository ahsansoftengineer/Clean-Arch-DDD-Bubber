using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simple.Treavor.Domain.Model;
using Simple.Treavor.Infrastructure.Data;
using Simple.Treavor.Infrastructure.IRepo;

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
        var country = await UnitOfWork.Countries.Get(q => q.Id == id);
        var result = Mapper.Map<CountryDTO>(country);
        return Ok(result);
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, $"Something went wrong in the {nameof(Get)}");
        return StatusCode(500, "Internal Server Error, Please try again later");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryDTO data)
    {
      if (!ModelState.IsValid)
      {
        Logger.LogError($"Invalid POST attempt in {nameof(Create)}");
        return BadRequest(ModelState);
      }
      try
      {
        var result = Mapper.Map<Country>(data);
        await UnitOfWork.Countries.Insert(result);
        await UnitOfWork.Save();
        return CreatedAtRoute("Get", new { id = result.Id }, result);
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, $"Something went wrong in the {nameof(Create)}");
        return StatusCode(500, "Internal Server Error, Please try again later");
      }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryDTO data)
    {
      if (!ModelState.IsValid || id < 1)
      {
        Logger.LogError($"Invalid UPDATE attempt in {nameof(Update)}");
        return BadRequest(ModelState);
      }
      try
      {
        var search = await UnitOfWork.Countries.Get(q => q.Id == id);
        if (search == null)
        {
          Logger.LogError($"Invalid UPDATE attempt in {nameof(Update)}");
          return BadRequest("Submit Data is Invalid");
        }

        Mapper.Map(data, search);
        UnitOfWork.Countries.Update(search);
        await UnitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, $"Something went wrong in the {nameof(Update)}");
        return StatusCode(500, "Internal Server Error, Please try again later");
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (id < 1)
      {
        Logger.LogError($"Invalid DELETE attempt in {nameof(Delete)}");
        return BadRequest();
      }
      try
      {
        var search = await UnitOfWork.Countries.Get(q => q.Id == id);
        if (search == null)
        {
          Logger.LogError($"Invalid DELETE attempt in {nameof(Delete)}");
          return BadRequest("Submit id is Invalid");
        }

        await UnitOfWork.Countries.Delete(id);
        await UnitOfWork.Save();

        return NoContent();
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, $"Something went wrong in the {nameof(Delete)}");
        return StatusCode(500, "Internal Server Error, Please try again later");
      }
    }
  }
}
