using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;
using PokemonAPi.Exceptions;
using PokedexApi.Exceptions;
using PokemonAPi.Dtos;
using Microsoft.AspNetCore.Authorization;


namespace PokedexApi.AddControllers;

[ApiController]
[Authorize]
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
  [Authorize(Policy = "read")]
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
  [Authorize(Policy = "Write")]
    public async Task<ActionResult> DeleteOokemonById(Guid id, CancellationToken cancellationToken){
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent();//204
        }
        return NotFound();//404
    }

    //400 - badrequest (usuario ingreso un valor incorrecto)
    //409 - conflict (ya existe el resucrso que se quiere crear)
    //200 - ok (objeto de respuesta pokemon creado)
    //201 - created (pokemon creado, en headres de respuesta url de recurso creado)
   [HttpPost]
public async Task<ActionResult<PokemonResponse>> CreatePokemonRequest(
    [FromBody] CreatePokemonRequest Pokemon, CancellationToken cancellationToken)
{
    if (Pokemon == null)
    {
        return BadRequest(new { message = "Invalid request data." });
    }

    try
    {
        var createdPokemon = await _pokemonService.CreatePokemonAsync(Pokemon.ToModel(), cancellationToken);
        return CreatedAtAction(nameof(GetPokemonById), new { id = createdPokemon.Id }, createdPokemon.ToDto());
    }
    catch (PokemonAlreadyExistsException ex) // Captura cuando el Pokémon ya existe
    {
        return Conflict(new { message = ex.Message }); // Devuelve 409 Conflict
    }
    catch (PokemonValidationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
        }
}
  
   //PUT - localhost:port/api/v1/pokemons/ID
   //404 - Not Found (No existe el pokemon con el ID que se manda)
   //400 - Bad Request (El usuario manda un valor incorrecto)
   //409 - Conflict (Ya existe un pokemon con el mismo nombre)
   //204 - NoContext
  [HttpPut("{id}")]
public async Task<IActionResult> UpdatePokemon(Guid id, [FromBody] UpdatePokemonRequest pokemon, CancellationToken cancellationToken)
{
    try
    {
        await _pokemonService.UpdatePokemonAsync(id, pokemon.ToModel(), cancellationToken);
        return NoContent();
    }
    catch (PokemonAlreadyExistsException)
    {
        return Conflict(new { message = $"Pokemon already exists with the name: {pokemon.Name}" });
    }
    catch (PokemonValidationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
    catch (PokemonNotFoundException)
    {
        return NotFound();
    }
}
}