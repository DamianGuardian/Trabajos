using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;


namespace PokemonApi.Mappers;

public static class HobiesMappers
{
    public static HobiesEntity ToEntity(this Hobies hobies)
    {
        return new HobiesEntity
        {
            Id = hobies.Id,
            Name = hobies.Name,
            Top = hobies.Top
        };
    }

    public static Hobies ToModel(this HobiesEntity entity)
    {
        if (entity == null)
        {
            return null;
        }

        return new Hobies
        {
            Id = entity.Id,
            Name = entity.Name,
            Top = entity.Top
        };
    }

         public static Hobies ToModel(this CreateHobiesDto hobies)
    {
        return new Hobies
        {
            Id = Guid.NewGuid(),
            Name = hobies.Name,
            Top = hobies.Top
            
        };
    }

        public static HobiesResponseDto ToDto(this Hobies hobies)
    {
        return new HobiesResponseDto
        {
            Id = hobies.Id,
            Name = hobies.Name,
            Top = hobies.Top
        };
    }

}
