using System.Threading.Tasks;
using GotSeries.Api.Service.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GotSeries.Api.Service.DTOS.RESPONSE;

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
        public async Task<IActionResult> GetBattles()
        {
            var query = _dbcontext.Battles
                .Include(b => b.Location)
                .ThenInclude(l => l.Kingdom)
                .Include(b => b.BattleType)
                .AsQueryable();

            var total = await query.CountAsync();

            var data = await query
                .Select(b => new BattlelistDto
                {
                    id = b.Id,
                    name = b.Name,
                    battleType = b.BattleType.BattleType1,
                    Location = b.Location.Location2,
                })
                .ToListAsync();

            return Ok(new { Total = total, Data = data });
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
