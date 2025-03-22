using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace PokedexApi.Services;
public interface IHobbiesService
{
    Task<IHobbiesService?> GetHobbieById(int id, CancellationToken cancellationToken);
    Task<List<IHobbiesService>> GetHobbiesByName(string name, CancellationToken cancellationToken);

}
