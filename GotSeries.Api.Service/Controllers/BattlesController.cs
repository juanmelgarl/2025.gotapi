using System.Threading.Tasks;
using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.Domains.Constants;
using GotSeries.Api.Service.DTOS.RESPONSE;
using GotSeries.Api.Service.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly GotDbContext _dbcontext;
        public BattlesController(GotDbContext dbContext)
            {
            _dbcontext = dbContext;
        }

        [HttpGet("/api/v1/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<List<personaje>> ListarBatallas(PaginatedRequest paginatedRequest)
        {
           
            return Ok(new List<personaje>());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> LeerBatalla(int id,charactertype charactertype)
        {
            var battle = await _dbcontext.Battles.FirstOrDefaultAsync(b => b.Id == id);
            return Ok(id);
        }

        [HttpGet("/api/v1/battles/{id}/participation")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListaCasas(int id, charactertype tipoPersonaje, PaginatedRequest paginatedRequest)
        {
            
            return Ok($"Casas  en batalla {id}");
        }

        [HttpPost("/api/v1/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult ModificarParticipante(int id, string participationType, int participantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { id, participationType, participantId });
        }

        [HttpDelete("/api/v1/battles/{id}/participation/{participationType}/{participantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult EliminarParticipante(int id, string participationType, int participantId)
        {
            return Ok($"Participante {participantId} eliminado de batalla {id}");
        }
    }
}
