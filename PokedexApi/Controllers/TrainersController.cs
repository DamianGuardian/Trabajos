using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PokedexApi.Dtos;
using PokedexApi.Exceptions;
using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Mappers;
using PokedexApi.Models;
using PokedexApi.Services;
using PokemonApi.Dtos;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _service;

        public TrainersController(ITrainerService service)
            => _service = service;

        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync(
            string key,
            CancellationToken cancellationToken)
        {
            key = key?.Trim(); // ✅ Línea añadida para evitar errores por espacios o saltos de línea

            if (ObjectId.TryParse(key, out _))
            {
                var byId = await _service.GetTrainerByIdAsync(key, cancellationToken);
                if (byId is null)
                    return NotFound(new { Message = $"No existe trainer con id '{key}'." });
                return Ok(byId.ToDto());
            }

            if (string.IsNullOrWhiteSpace(key) || key.Length < 2)
            {
                return BadRequest(new
                {
                    Message = "El nombre a buscar debe tener al menos 2 caracteres."
                });
            }

            var results = new List<TrainerResponseDto>();
            await foreach (var t in _service.GetTrainersByNameAsync(key, cancellationToken))
            {
                results.Add(t.ToDto());
            }

            if (!results.Any())
                return NotFound(new
                {
                    Message = $"No se encontraron trainers con nombre que contenga '{key}'."
                });

            return Ok(results);
        }


                [HttpPost]
        public async Task<ActionResult> CreateTrainerAsync(
            [FromBody] List<CreateTrainerRequestDto> request,
            CancellationToken cancellationToken)
        {
            var trainers = request.ToModel();
            var (createdTrainers, successCount) = await _service.CreateTrainerAsync(trainers, cancellationToken);
        
            return Ok(new { successCount, createdTrainers });
        }

    }
}
