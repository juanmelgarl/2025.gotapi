using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        [HttpGet("/api/v1/battles")]
        public IActionResult ListarBatallas()
        {
            return Ok("soy una batalla");
        }

        [HttpGet("/api/v1/battles/{id}")]
        public IActionResult leerbatalla()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/battles/{id}/participation")]
        public IActionResult listacasas()
        {
            throw new NotImplementedException();
        }
        [HttpPost("/api/v1/battles")]
        public IActionResult crearbatalla()
        {
            throw new NotImplementedException();
        }
        [HttpPost("/api/v1/battles/{id}/participation")]
        public IActionResult agregarparticipante(int agregarparticipante)
        {
            return Ok("nuevo participante creado");
        }

        [HttpPut("/api/v1/battles/{id}/participation/\r\n{participationType}/{participant\r\nId}")]
        public IActionResult modificarparticipante()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("/api/v1/battles/{id}/participation/\r\n{participationType}/{participant\r\nId}")]
        public IActionResult delete()
        {
            throw new NotImplementedException();
        }
    }
}
