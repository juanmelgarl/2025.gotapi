using System.Threading.Tasks;
using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.Domains.Constants;
using GotSeries.Api.Service.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GotSeries.Api.Service.DTOS.RESPONSE;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly GotDbContext _dbcontext;

        public List<BattleparticipantDto> Participants { get; private set; } = new();

        public BattlesController(GotDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        [Route("api/battles")]
        public async Task<IActionResult> GetBattles([FromQuery] PaginatedRequest page)
        {
            var query = _dbcontext.Battles
                .Include(b => b.Location)
               
                    .ThenInclude(l => l.Kingdom)
                .Include(b => b.BattleType)
                .AsQueryable();

            var total = await query.CountAsync();

            var data = await query
                .Skip((page.Pagenumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .Select(b => new BattlelistDto
                {
                    id = b.Id,
                    name = b.Name,
                    battleType = b.BattleType.BattleType1,
                })
                .ToListAsync();

            return Ok(new { Total = total, Data = data });
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBattleById(int id)
        {
     

            return Ok(id);
        }


        [HttpPost("/api/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CrearBatalla()
        {
            return Ok();
        }

        [HttpPost("/api/battles/{id}/participation")]
        public IActionResult AgregarParticipante(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"Nuevo participante agregado a batalla {id}");
        }

        [HttpPut("/api/battles/{id}/participation/{participationType}/{participantId}")]
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

        [HttpDelete("/api/battles/{id}/participation/{participationType}/{participantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult EliminarParticipante(int id, string participationType, int participantId)
        {
            return Ok($"Participante {participantId} eliminado de batalla {id}");
        }
    }
}
