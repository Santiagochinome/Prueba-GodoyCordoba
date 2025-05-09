using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly PersistentHistoryService _historyService;

        public HistoryController(PersistentHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var history = await _historyService.GetAllAsync();
            return Ok(history);
        }
    }
}
