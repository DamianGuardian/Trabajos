using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;


namespace PokedexApi.AddControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }


    //localhost/api/v1/pokemons/12971293-1283812
  [HttpGet("{id}")]
  public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
  {
    var pokemon = await _pokemonService.GetPokemonById(id, cancellationToken);
    if (pokemon is null){
    return NotFound();
    }
    return Ok(pokemon.ToDto());
  }
  

//localhost/api/v1/pokemons?name=pikachu
  [HttpGet]
  public async Task<ActionResult<PokemonResponse>> GetPokemonByName([FromQuery] string name, CancellationToken cancellationToken)
  {
    var pokemon = await _pokemonService.GetPokemonByName(name, cancellationToken);
    if (pokemon is null){
    return NotFound();
    }
    return Ok(pokemon.ToDto());
  }

  [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOokemonById(Guid id, CancellationToken cancellationToken){
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent();//204
        }
        return NotFound();//404
    }
}