using System.ServiceModel;
using PokedexApi.Dtos;
using PokemonApi.Dtos;


namespace PokedexApi.Infrastructure.Soap.Contracts;

[ServiceContract(Name = "PokemonService", Namespace = "http://pokemonapi/pokemon-service")]
public interface IPokemonService
{
    [OperationContract]
    Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken);

    [OperationContract]
    Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon, CancellationToken cancellationToken);

    [OperationContract]
    Task<PokemonResponseDto> GetPokemonByName(string name, CancellationToken cancellationToken);
    Task GetByName(string name, CancellationToken cancellationToken);
    Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);
}
