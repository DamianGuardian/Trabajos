using System.ServiceModel;
using HobbieApi.Controllers;
using HobiesApi.Infrastructure.Soap.Contracts;
using PokemonAPi.Services;


namespace PokedexApi.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly ILogger<HobbyRepository> _logger;
        private readonly IHobbieService _hobbyService;

        public HobbyRepository(ILogger<HobbyRepository> logger, IConfiguration configuration)
        {
            _logger = logger;

            var endpointUri = configuration.GetValue<string>("HobbyServiceEndpoint");

            if (string.IsNullOrEmpty(endpointUri))
            {
                throw new ArgumentNullException(nameof(endpointUri), "HobbyServiceEndpoint cannot be null or empty.");
            }

            if (!endpointUri.StartsWith("http://"))
            {
                endpointUri = "http://" + endpointUri;  
            }

            var endpoint = new EndpointAddress(endpointUri);
            var binding = new BasicHttpBinding();

            _hobbyService = new ChannelFactory<IHobbieService>(binding, endpoint).CreateChannel();
        }

        public async Task<IHobbyRepository?> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _logger.LogWarning("Invalid GUID provided.");
                    return null;
                }

                var hobby = await _hobbyService.GetHobbieById(id, cancellationToken);
                return hobby.ToModel();
            }
            catch (FaultException ex) when (ex.Message == "Hobby not found :(")
            {
                _logger.LogWarning(ex, "Failed to get hobby with id: {id}", id);
                return null;
            }
        }

        public async Task<List<IHobbyRepository>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    _logger.LogWarning("Invalid hobby name provided.");
                    return new List<IHobbyRepository>();
                }

                var hobby = await _hobbyService.GetHobbieByName(name, cancellationToken);
                return hobby.Select(h => h.ToModel()).Where(h => h != null).ToList();
            }
            catch (FaultException ex) when (ex.Message == "Hobby not found :(")
            {
                _logger.LogWarning(ex, "Failed to get hobby with name: {name}", name);
                return new List<IHobbyRepository>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting hobby with name: {name}", name);
                throw; 
            }
        }
    }

    internal class ChannelFactory<T>
    {
        private BasicHttpBinding binding;
        private EndpointAddress endpoint;

        public ChannelFactory(BasicHttpBinding binding, EndpointAddress endpoint)
        {
            this.binding = binding;
            this.endpoint = endpoint;
        }

        internal IHobbieService? CreateChannel()
        {
            throw new NotImplementedException();
        }
    }

    internal class BasicHttpBinding
    {
        public BasicHttpBinding()
        {
        }
    }

    internal class EndpointAddress
    {
        private string endpointUri;

        public EndpointAddress(string endpointUri)
        {
            this.endpointUri = endpointUri;
        }
    }
}