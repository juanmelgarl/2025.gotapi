using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GotSeries.Api.Service.Code;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GotSeries.Api.Service.Infrastructure.Data;
using GotSeries.Api.Service.DTOS.Response;
using System.Security.Cryptography.Xml;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase

    {

        private readonly GotDbContext _dbContext;

        public BattlesController(GotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{id:int}")]
        public ActionResult<BattleDto> BuscarporID([FromRoute] int id)
        {
            var battle = _dbContext.Battles
                  .Include(b => b.BattleType)
                  .Include(l => l.Location)
                  .ThenInclude(l => l.Kingdom)
                  .Where(b => b.Id == id)
                  .Select(b => new BattleDto
                  {
                      id = b.Id,
                      name = b.Name,
                      year = b.Year,
                      amountAttackerSoldiers = b.AmountAttackerSoldiers,
                      amountDefenderSoldiers = b.AmountDefenderSoldiers,
                      hasMayorCapture = b.HasMayorCapture,
                      hasMayorDeath = b.HasMayorDeath,
                      battleType = b.BattleType != null ? b.BattleType.BattleType1 : "Sin tipo",
                      location = b.Location == null ? null : new LocationDto
                      {
                          id = b.Location.Id,
                          name = b.Location.Name,
                          url = b.Location.Url,
                          summary = b.Location.Summary,
                          kingdom = b.Location.Kingdom == null ? null : new KingdomDto
                          {
                              id = b.Location.Kingdom.Id,
                              name = b.Location.Kingdom.Name,
                              summary = b.Location.Kingdom.Summary,
                              url = b.Location.Kingdom.Url
                          }
                      }
                  })
                   .ToList();
            if (battle == null)
            {
                return NotFound("no se encontro la batalla");
            }
            return Ok(battle);
                         
                   
        
    }

        
        [HttpDelete("/api/v1/battles/{id}/participation/\r\n{participationType}/{participant\r\nId}")]
        public IActionResult Borrarparticipante()
        {
            return Ok();
        }
        [HttpGet("/api/v1/characters/{characterType}")]
        public IActionResult Listarpersonajes()
        {
            return Ok();
        }



        [HttpGet("/api/v1/battles")]
        public ActionResult<List<BattleListDto>> BuscarBatalla()
        {
            var battles = _dbContext.Battles
                .Include(b => b.BattleType)
                .Include(b => b.Location)
                .ThenInclude(l => l.Kingdom)
                .AsNoTracking() 
                .Select(b => new BattleListDto
                {
                    id = b.Id,
                    name = b.Name,
                    amountAttackerSoldiers = b.AmountAttackerSoldiers,
                    amountDefenderSoldiers = b.AmountDefenderSoldiers,
                    hasMayorCapture = b.HasMayorCapture,
                    hasMayorDeath = b.HasMayorDeath,
                    year = b.Year,

                    battleType = b.BattleType != null ? b.BattleType.BattleType1 : "Sin tipo",
                    battleTypeId = b.BattleTypeId ?? 0,

                    location = b.Location != null ? new LocationDto
                    {
                        id = b.Location.Id,
                        name = b.Location.Name ?? "Desconocido",
                        summary = b.Location.Summary ?? "",
                        url = b.Location.Url ?? "",
                        kingdom = b.Location.Kingdom != null ? new KingdomDto
                        {
                            id = b.Location.Kingdom.Id,
                            name = b.Location.Kingdom.Name ?? "Sin Reino",
                            summary = b.Location.Kingdom.Summary ?? "",
                            url = b.Location.Kingdom.Url ?? ""
                        } : null
                    } : null
                })
                .ToList();

            return Ok(battles);
        }


        [HttpGet("/api/v1/battles/{id}/participation")]
        public ActionResult<List<BattleParticipantDto>> Listarparticipante([FromRoute] int id)
        {
            var Participante = _dbContext.Battles
                .Include(b => b.BattleHouses)
                .Include(x => x.BattleCommanders)
               .Include(c => c.BattleKings)
               .FirstOrDefault(b => b.Id == id);
            if (Participante == null)
                return NotFound("no se encontro la batalla");

            var participantes = new List<BattleParticipantDto>();
            if (Participante.BattleHouses != null)
            {
                participantes.AddRange(
                    Participante.BattleHouses.Select(h => new BattleParticipantDto
                              

                    {
                        id = h.House.Id,
                        name = h.House.Name,
                        participationType = 1,
                        isAttacker = h.IsAttacker,
                        isDeath = false,
                        isCommander = false,
                        isHumman = false,
                        isKing = false,
                        isGeneric = true,
                        isRoyalty = false,

                    })
                   );
            }
            if (Participante.BattleKings != null)
            {
                participantes.AddRange(
                    Participante.BattleKings.Select(k => new BattleParticipantDto
                    {
                        id = k.King.Id,
                        name = k.King.Name,
                        participationType = 2, // 2 = Rey
                        isAttacker = k.IsAttacker,
                        isCommander = false,
                        isDeath = false,
                        isGeneric = false,
                        isHumman = true,
                        isKing = true,
                        isRoyalty = true
                    })
                );
            }

            if (Participante.BattleCommanders != null)
            {
                participantes.AddRange(
                    Participante.BattleCommanders.Select(c => new BattleParticipantDto
                    {
                        id = c.Commander.Id,
                        name = c.Commander.Name,
                        participationType = 3, 
                        isAttacker = c.IsAttacker,
                        isCommander = true,
                        isDeath = false,
                        isGeneric = false,
                        isHumman = true,
                        isKing = false,
                        isRoyalty = false
                    })
                );
            }

            return Ok(participantes);
        }
                
        
        [HttpPut("/api/v1/battles/{id}/participation/\r\n{participationType}/{participant\r\nId}")]
        public ActionResult Modificarparticipante()
        {
            return
               Ok();
        }

        [HttpPost("/api/v1/battles")]
        public async Task<IActionResult> CreateBatalla()
        {

            return Ok();
        }
        [HttpDelete("v1/battles/{id}")]
        public ActionResult<BattleDto> BorrarBatalla(int id)
        {
            return Ok();

        }
     



    }
}



