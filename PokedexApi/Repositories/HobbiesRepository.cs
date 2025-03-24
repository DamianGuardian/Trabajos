using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Mappers;
using PokemonApi.Models;
using Microsoft.Extensions.Logging;

namespace PokedexApi.Repositories;

public class HobbiesRepository : IHobbiesRepository
{
    private readonly ILogger<HobbiesRepository> _logger;
    private readonly IHobbiesService _hobbiesService;

    // Constructor con inyección de dependencias
    public HobbiesRepository(ILogger<HobbiesRepository> logger, IHobbiesService hobbiesService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _hobbiesService = hobbiesService ?? throw new ArgumentNullException(nameof(hobbiesService));
    }

    // Obtener un hobby por ID
    public async Task<Hobbies?> GetHobbyByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Invalid ID {Id} for GetHobbyByIdAsync.", id);
            return null;
        }

        try
        {
            var hobbies = await _hobbiesService.GetHobbiesById(id, cancellationToken);
            return hobbies?.ToModel();
        }
        catch (FaultException ex) when (ex.Message == "Hobbies not found :(")
        {
            _logger.LogWarning(ex, "Hobby with ID {Id} not found.", id);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving hobby with ID {Id}.", id);
            throw;
        }
    }

    // Obtener hobbies por nombre
    public async Task<List<Hobbies>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogWarning("Invalid name parameter for GetHobbiesByNameAsync.");
            return new List<Hobbies>();
        }

        try
        {
            var hobbies = await _hobbiesService.GetHobbieByName(name, cancellationToken);
            return hobbies?.Select(h => h.ToModel()).ToList() ?? new List<Hobbies>();
        }
        catch (FaultException ex) when (ex.Message.Contains("Hobbie not found"))
        {
            _logger.LogWarning(ex, "No hobbies found with name: {Name}", name);
            return new List<Hobbies>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving hobbies with name: {Name}", name);
            throw;
        }
    }

    // Eliminar hobby por ID
    public async Task<bool> DeleteHobbies(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Invalid ID {Id} for deletion.", id);
            return false;
        }

        try
        {
            return await _hobbiesService.DeleteHobbies(id, cancellationToken);
        }
        catch (FaultException ex) when (ex.Message.Contains("Hobbie not found"))
        {
            _logger.LogWarning(ex, "Hobby with ID {Id} not found.", id);
            return false;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Operation canceled while deleting hobby with ID {Id}.", id);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while deleting hobby with ID {Id}.", id);
            return false;
        }
    }
}
