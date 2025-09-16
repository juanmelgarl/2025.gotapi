using GotSeries.Api.Service.Domains.Constants;
using GotSeries.Api.Service.DTOS.RESPONSE;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        [HttpGet("/api/v1/battles")]
        public ActionResult<List<personaje>> ListarBatallas()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/api/v1/battles/{id}")]
        public IActionResult LeerBatalla(int id, charactertype tipoPersonaje)

        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/battles/{id}/participation")]
        public IActionResult listacasas(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("/api/v1/battles")]
        public IActionResult crearbatalla()
        {
            throw new NotImplementedException();
        }
        [HttpPost("/api/v1/battles/{id}/participation")]
        public IActionResult agregarparticipante(int id)
        {
            return Ok("nuevo participante creado");
        }

        [HttpPut("/api/v1/battles/{id}/participation/\r\n{participationType}/{participant\r\nId}")]
        public IActionResult modificarparticipante(int id,int participation)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("/api/v1/battles/{id}/participation/\r\n{participationType}/{participant\r\nId}")]
        public IActionResult delete(int id,int participation)
        {
            throw new NotImplementedException();
        }
    }
}
