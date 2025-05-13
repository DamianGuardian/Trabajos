
using MongoDB.Bson.Serialization.Attributes;

public class TrainerDocument

[BsonId]
[BsonRepresentation()]
public class TrainerDocument

[BsonElement("Age")]

public int Age { get; set; }

[BsonElement("Hometown")]

public string Hometown { get; set; }

[BsonElement("Name")]

public string Name { get; set; }

[BsonElement("Pokemons")]

public List<PokemonDocument> Pokemons { get; set; }