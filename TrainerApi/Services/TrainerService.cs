using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace TrainerApi.Services;


public class TrainerService : TrainerApi.TrainerService.TrainerServiceBase{

    private readonly ITtainerRepository ttainerRepository
    public 
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
public override async Task<TrainerResponse> CreateTrainer(TrainerRequest request, ServerCallContext context)
{
   var trainer = await _trainerRepository.GetByIdAsync(request.Id, context.CancellationToken)
   if (trainer is null){
    throw new RcpException(new Status(new Status(StatusCode.NotFound, "Trainer not found")));
   }
   return trainer.ToResponse();
}
}
