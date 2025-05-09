using API.Models;
using API.Models.CatFactApi.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactController : ControllerBase
    {
        private readonly CatFactService _catFactService;

        public FactController(CatFactService catFactService)
        {
            _catFactService = catFactService;
        }

        [HttpGet]
        public async Task<ActionResult<CatFact>> Get()
        {
            var fact = await _catFactService.GetRandomFactAsync();

            if (fact == null)
            {
                return NotFound("No se pudo obtener el dato.");
            }

            return Ok(fact);
        }
    }
}
