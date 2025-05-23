using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Models;
using PokemonApi.Dtos;

namespace PokedexApi.Mappers;

public static class TrainerMappers {
    public static TrainerResponseDto ToDto(this Trainer trainer)
    {
        return new TrainerResponseDto
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            Birthdate = trainer.Birthdate,
            CreatedAt = trainer.CreatedAt,
            Medals = trainer.Medals
                .Select(s => new MedalDto
                {
                    Region = s.Region,
                    Type = s.Type
                })
                .ToList()
        };
    }
 public static Trainer ToModel(this TrainerResponse trainer)
    {
        return new Trainer
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            Birthdate = trainer.Birthdate.ToDateTime(),
            CreatedAt = trainer.CreatedAt.ToDateTime(),
            Medals = trainer.Medals .Select(s => new Medal{
                Region = s.Region,
                Type = s.Type.ToString()
            }) .ToList()
        };
    }
}