using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.DTOS.REQUEST;
using GotSeries.Api.Service.DTOS.RESPONSE;
using GotSeries.Api.Service.Infrastructure.Data;
using GotSeries.Api.Service.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly GotDbContext _dbcontext;

        public BattlesController(GotDbContext dbContext) => _dbcontext = dbContext;



                [HttpGet("{id:int}")]
             public ActionResult<battledto> BuscarporID([FromRoute] int id) 
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id <= 0)
                return BadRequest("El id debe ser mayor que cero.");
    

            var battle = _dbcontext.Battles
                .Where(b => b.Id == id)
                .Select(p => new battledto
                {
                    id = p.Id,
                    name = p.Name,
                    year = p.Year,
                    amountAttackerSoldiers
                        = p.AmountAttackerSoldiers,
                    hasMayorCapture = p.HasMayorCapture,
                    attackerWon = p.AttackerWon,
                    amountDefenderSoldiers = p.AmountDefenderSoldiers,
                    hasMayorDeath = p.HasMayorDeath,
                    notes = p.Notes,
                    battleType = p.BattleType != null ? p.BattleType.BattleType1 ?? string.Empty : string.Empty,
                    
                   
                   
                })
                .FirstOrDefault();

            if (battle == null)
                return NotFound("no se encontro la batalla con esa id.");
            
            return Ok(battle);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateBatalla([FromBody] CreateBattleDto createBattle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battletypeexists = await _dbcontext.BattleTypes.AnyAsync(b => b.Id == createBattle.battleTypeId);
            if (!battletypeexists)
            {
                return NotFound("no se encontro la batalla indicada");
            }

            var locationexits = await _dbcontext.Locations.AnyAsync(x => x.Id == createBattle.locationId);
            if (!locationexits)
                return NotFound("error");

            var newbattle = new GotSeries.Api.Service.Infrastructure.Data.Entities.Battle
            {
                BattleTypeId = createBattle.battleTypeId,
               
                
                Name = createBattle.name,
                Notes = createBattle.notes,
                Year = createBattle.year,
                AmountAttackerSoldiers = createBattle.amountAttackerSoldiers,
                AmountDefenderSoldiers = createBattle.amountDefenderSoldiers,
                LocationId = createBattle.locationId,
                HasMayorCapture = createBattle.hasMayorCapture,
                HasMayorDeath = createBattle.hasMayorDeath,
                AttackerWon  = createBattle.attackerWon,
            };
            _dbcontext.Battles.Add(newbattle);
            await _dbcontext.SaveChangesAsync();

            return Ok(newbattle);
        }
    }
}
