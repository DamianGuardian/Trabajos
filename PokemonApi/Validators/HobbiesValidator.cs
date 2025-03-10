using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Validators;

public static class HobbiesValidator
{

    public static Hobies ValidateId(this Hobies hobies) =>
    hobies.Id == Guid.Empty ? throw new FaultException("Hobies is required") : hobies;


    public static Hobies ValidateName(this Hobies hobies) =>
        string.IsNullOrWhiteSpace(hobies.Name) ?
        throw new FaultException("Hobies is requerid") : hobies;

    public static Hobies ValidateTop(this Hobies hobies) =>
        hobies.Top <= 0 ? throw new FaultException("Hobies is requerid") : hobies;
        
}

