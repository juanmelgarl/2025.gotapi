using System.Threading.Tasks;
using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.DTOS.RESPONSE;
using GotSeries.Api.Service.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<List<BattlelistDTO>>> GetBattles([FromQuery] PaginatedRequest pageRequest)
        {
            var query = _dbcontext.Battles
                .Include(b => b.BattleType)
                .Include(b => b.Location.Kingdom)          
                .Select(b => new BattlelistDTO
                {
                    id = b.Id,
                    name = b.Name,
                    battleType = b.BattleType.BattleType1,
                    location = new Location(),
                    kingdom = b.Location.Kingdom.Name
                });

            var paginatedResult = await query
                .Skip((pageRequest.Pagenumber - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize)
                .ToListAsync();

            return Ok(paginatedResult);
        }
    


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBattleById(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult CrearBatalla()
        {
            return Ok();
        }

        [HttpPost("{id}/participation")]
        public IActionResult AgregarParticipante(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Nuevo participante agregado a batalla {id}");
        }

        [HttpPut("{id}/participation/{participationType}/{participantId}")]
        public IActionResult ModificarParticipante(int id, string participationType, int participantId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new { id, participationType, participantId });
        }

        [HttpDelete("{id}/participation/{participationType}/{participantId}")]
        public IActionResult EliminarParticipante(int id, string participationType, int participantId)
        {
            return Ok($"Participante {participantId} eliminado de batalla {id}");
        }
    }
}
