using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GifController : ControllerBase
    {
        private readonly GifService _gifService;
        private readonly SearchHistoryService _historyService;
        private readonly PersistentHistoryService _dbService;
        private readonly CatFactService _catFactService;

        public GifController(GifService gifService, SearchHistoryService historyService, PersistentHistoryService dbService, CatFactService catFactService)
        {
            _gifService = gifService;
            _historyService = historyService;
            _dbService = dbService;
            _catFactService = catFactService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var catFactObj = await _catFactService.GetRandomFactAsync();
            if (catFactObj == null || string.IsNullOrWhiteSpace(catFactObj.Fact))
            {
                return StatusCode(502, "Error al obtener el dato de catfact.");
            }

            var fact = catFactObj.Fact;
            var query = string.Join(" ", fact.Split(" ").Take(3));

            var gifUrl = await _gifService.SearchGifAsync(query);
            if (gifUrl == null)
            {
                return NotFound("No se encontraron resultados para el GIF.");
            }

            _historyService.Add(new SearchHistoryItem
            {
                Query = query,
                GifUrl = gifUrl,
                CatFact = fact
            });

            await _dbService.SaveAsync(fact, query, gifUrl);

            return Ok(new { fact, gifUrl });
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshGif([FromQuery] string fact)
        {
            if (string.IsNullOrWhiteSpace(fact))
                return BadRequest("El 'fact' no puede estar vacío.");

            var query = string.Join(" ", fact.Split(' ').Take(3));
            var gifUrl = await _gifService.SearchGifAsync(query);

            if (gifUrl == null)
                return NotFound("No se encontraron resultados para el GIF.");

            _historyService.Add(new SearchHistoryItem
            {
                Query = query,
                GifUrl = gifUrl,
                CatFact = fact 
            });

            await _dbService.SaveAsync(fact, query, gifUrl);

            return Ok(new { gifUrl });
        }

    }
}
