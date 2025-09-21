using Microsoft.AspNetCore.Mvc;
using TT.Application.Interfaces;

namespace TT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var response = await _service.GetAvailableAsync();
            return StatusCode(response.StatusCode, response);
        }
    }
}
