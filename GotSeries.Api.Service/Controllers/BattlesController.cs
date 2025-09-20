using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.Domains.Constants;
using GotSeries.Api.Service.DTOS.RESPONSE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        [HttpGet("/api/v1/battles")]
        public ActionResult<List<personaje>> ListarBatallas(PaginatedRequest paginatedRequest)
        {
           
            return Ok(new List<personaje>());
        }

        [HttpGet("/api/v1/battles/{id}")]
        public IActionResult LeerBatalla(int id, [FromQuery] charactertype tipoPersonaje, CharacterDto dto)
        {
          
            return Ok(new { id, tipoPersonaje });
        }

        [HttpGet("/api/v1/battles/{id}/participation")]
        public IActionResult ListaCasas(int id, charactertype tipoPersonaje, PaginatedRequest paginatedRequest)
        {
            
            return Ok($"Casas  en batalla {id}");
        }

        [HttpPost("/api/v1/battles")]
        public IActionResult CrearBatalla()
        {

            return Ok();
            }
          


                [HttpPost("/api/v1/battles/{id}/participation")]
                public IActionResult AgregarParticipante(int id)
                {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                    return Ok($"Nuevo participante agregado a batalla {id}");
                }

        [HttpPut("/api/v1/battles/{id}/participation/{participationType}/{participantId}")]
        public IActionResult ModificarParticipante(int id, string participationType, int participantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { id, participationType, participantId });
        }

        [HttpDelete("/api/v1/battles/{id}/participation/{participationType}/{participantId}")]
        public IActionResult EliminarParticipante(int id, string participationType, int participantId)
        {
            return Ok($"Participante {participantId} eliminado de batalla {id}");
        }
    }
}
