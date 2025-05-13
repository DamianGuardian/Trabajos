using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrainerApi.Models;

namespace TrainerApi.Repositories;

public class TrainerRepository : ITrainerRepository
{
   private readonly IMongoCollection<TrainerDocument> _trainersCollection;


   public TrainerRepository(IMongoDatabase database,
   IOptions<MongoDBSettings> settings){
        _trainersCollection =
        database.GetCollection<TrainerDocument>(settings.Value.TrainerCollectionName);
    }
    úblic async async Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        var trainer = await _trainersCollection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        return trainer?.ToModel();
    }
    }

