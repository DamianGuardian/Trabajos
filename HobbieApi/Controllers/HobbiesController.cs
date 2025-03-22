using HobbieApi.Dtos;
using HobiesApi.Infrastructure.Soap.Contracts;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokemonApi.Dtos;


namespace HobbieApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class HobbiesController : ControllerBase
{
    private readonly IHobbieService _hobbyService;

    public HobbiesController(IHobbieService hobbyService)
    {
        _hobbyService = hobbyService;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<HobbiesResponse>> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var hobby = await _hobbyService.GetHobbyByIdAsync(id, cancellationToken);
        if (hobby == null)
        {
            return NotFound();
        }
        return Ok(hobby);
    }

    [HttpGet("name/{name}")]

    public async Task<ActionResult<List<HobbiesResponse>>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken)
    {
        var hobbies = await _hobbyService.GetHobbiesByNameAsync(name, cancellationToken);
        if (hobbies == null)
        {
            return NotFound();
        }
        return Ok(hobbies);
    }

}

public interface IHobbieService
{
    Task<HobbiesResponse> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<HobbiesResponse>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken);
}

