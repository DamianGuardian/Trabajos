using PokedexApi.Dtos;
using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Models;
using PokemonApi.Dtos;

namespace PokedexApi.Mappers;

public static class TrainerMapper
{
    public static TrainerResponseDto ToDto(this Trainer trainer)
    {
        if (trainer is null)
        {
            return null;
        }

        return new TrainerResponseDto
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            CreatedAt = trainer.CreatedAt,
            Medals = trainer.Medals.Select(m => new MedalDto
            {
                Region = m.Region,
                Type = m.Type
            }).ToList()
        };
    }
    public static Trainer ToModel(this TrainerResponse trainer)
    {
        if (trainer is null)
        {
            return null;
        }

        return new Trainer
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            Birthdate = trainer.Birthdate.ToDateTime(),
            CreatedAt = trainer.CreatedAt.ToDateTime(),
            Medals = trainer.Medals.Select(m => new Medal
            {
                Region = m.Region,
                Type = m.Type.ToString()
            }).ToList()
        };
    }

    public static IEnumerable<TrainerResponseDto> ToDto(this IEnumerable<Trainer> trainers)
    {
        return trainers.Select(s => s.ToDto());
    }

    public static List<Trainer> ToModel(this List<CreateTrainerRequestDto> request)
    {
        return request.Select(s => new Trainer
        {
            Name = s.Name,
            Age = s.Age,
            Birthdate = s.BirthDate,
            Medals = s.Medals.Select(m => new Medal
            {
                Region = m.Region,
                Type = m.Type
            }).ToList()
        }).ToList();
    }

    public static List<Trainer> ToModel(this Google.Protobuf.Collections.RepeatedField<TrainerResponse> trainer)
    {
        return trainer.Select(s => s.ToModel()).ToList();
    }
}
