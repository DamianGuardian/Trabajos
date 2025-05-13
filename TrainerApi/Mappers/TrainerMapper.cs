
using TrainerApi.Models;

namespace TrainerApi.Mappers;

public static class TrainerMapper{
    public static Trainer? ToModel(this TrainerDocument trainerDocument)
    if (Trainer is null)

}

return new Trainer {
    Id = Trainer.Id,
    Age = Trainer.Age,
    Name = Trainer.Name,
    Birthdate = Trainer.Birthdate,
    CreatedAt = Trainer.CreatedAt,
    Medals = Trainer.Medals.Select(m => m.ToModel()).ToList()
    Region = sbyte.Region,
    

}