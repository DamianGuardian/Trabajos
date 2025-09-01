using System.Runtime.Serialization;

namespace HobbieApi.Dtos;


public class HobbiesResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Top { get; set; }
    
    
}