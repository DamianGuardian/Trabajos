using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace TrainerApi.Services;


public class TrainerService : TrainerApi.TrainerService.TrainerServiceBase{
    public override async Task<TrainerResponse> GetTrainer(TrainerByIdRequest request, ServerCallContext context)
    {
        return new TrainerResponse{
            Id = Guid.NewGuid().ToString(),
            Name = "Pascual",
            Age = 99,
            Birthdate = Timestamp.FromDateTime(DateTime.UtcNow),
            CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow),
            Medals    = {
            new Medals{ Region = "MX", Type = MedalsType.Gold },
            new Medals{ Region = "JP", Type = MedalsType.Silver }
        }
    };
}
}
