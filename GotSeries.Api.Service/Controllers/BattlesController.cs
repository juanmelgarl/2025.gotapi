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
using GotSeries.Api.Service.Infrastructure.Data.Entities;
using GotSeries.Api.Service.DTOS;
using GotSeries.Api.Service.DTOS.Request;

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


        [HttpDelete("/api/v1/battles/{battleid}/participation/\r\n{participationType}/{participationId}")]
        public IActionResult Borrarparticipante(int battleid, int participantionid, string participationType)
        {
            return Ok();
        }
        [HttpGet("{characterType?}")]
        public IActionResult Listarpersonajes(string characterType)
        {

            var personajes = _dbContext.Characters
                   .Select(x => new CharacterDto
                   {
                       id = x.Id,
                       name = x.Name,
                       IsDeath = x.IsDeath,
                       IsCommander = x.IsCommander,
                       IsHuman = x.IsHuman,
                       IsKing = x.IsKing,
                       IsGeneric = x.IsGeneric,
                   })
                   .ToList();
            return Ok(personajes);

        }



        [HttpGet("/api/v1/battles")]
        public ActionResult<List<BattleListDto>> BuscarBatalla()
        {
            var battles = _dbContext.Battles
                .Select(b => new BattleListDto
                {
                    id = b.Id,
                    name = b.Name,
                    year = b.Year,
                    amountAttackerSoldiers = b.AmountAttackerSoldiers,
                    amountDefenderSoldiers = b.AmountDefenderSoldiers,
                    hasMayorCapture = b.HasMayorCapture,
                    hasMayorDeath = b.HasMayorDeath,
                    battleTypeId = b.BattleTypeId ?? 0,
                    battleType = b.BattleType.BattleType1,
                    location = b.Location == null ? null : new LocationDto
                    {
                        id = b.Location.Id,
                        name = b.Location.Name,
                        kingdom = b.Location.Kingdom == null ? null : new KingdomDto
                        {
                            id = b.Location.Kingdom.Id,
                            summary = b.Location.Kingdom.Summary,
                            url = b.Location.Kingdom.Url,
                            name = b.Location.Kingdom.Name
                        },

                        url = b.Location.Url,
                        summary = b.Location.Summary,

                    }

                })
                .ToList();

            return Ok(battles);
        }

        [HttpPost("/api/v1/battles/{battleid}/participation")]
        public ActionResult Agregarparticipante([FromRoute] int battleId, [FromBody] BattleParticipantDto dto)

        {
            var battle = _dbContext.Battles.Find(battleId);
            if (battle == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrada",
                    Detail = $"No existe la batalla con el id {battleId}",
                    Status = 404
                });
            }

            var personaje = _dbContext.Characters.Find(dto.id);
            if (personaje == null)
            {
                return NotFound("Personaje no encontrado");
            }
            if (dto.IsCommander)
            {
                _dbContext.BattleCommanders.Add(new BattleCommander
                {
                    BattleId = battleId,
                    CommanderId = dto.id,
                    IsAttacker = dto.isAttacker
                });
            }
            else if (dto.IsKing)
            {
                _dbContext.BattleKings.Add(new BattleKing
                {
                    BattleId = battleId,
                    KingId = dto.id,
                    IsAttacker = dto.isAttacker
                });
            }


            _dbContext.SaveChanges();
            return Ok();
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
                        IsDeath = false,
                        IsCommander = false,
                        IsHuman = false,
                        IsKing = false,
                        IsGeneric = true,
                        IsRoyalty = false,

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
                        IsCommander = false,
                        IsDeath = false,
                        IsGeneric = false,
                        IsHuman = true,
                        IsKing = true,
                        IsRoyalty = true
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
                        IsCommander = true,
                        IsDeath = false,
                        IsGeneric = false,
                        IsHuman = true,
                        IsKing = false,
                        IsRoyalty = false

                    })
                );
            }

            return Ok(participantes);
        }


        [HttpPut("/api/v1/battles/{id}/participation/\r\n{participationType}/{participantionId}")]
        public ActionResult Modificarparticipante(int id, string participationType, int participantId)
        {
            {
                var personaje = _dbContext.Characters.Find(id);
            }
        }
            [HttpPost("/api/v1/battles")]
            public ActionResult CreateBatalla([FromBody] CreateBattleDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var batalla = new GotSeries.Api.Service.Infrastructure.Data.Entities.Battle
                {
                    Name = dto.name,
                    AmountAttackerSoldiers = dto.amountAttackerSoldiers,
                    AmountDefenderSoldiers = dto.amountDefenderSoldiers,
                    AttackerWon = dto.attackerWon,
                    HasMayorCapture = dto.hasMayorCapture,
                    HasMayorDeath = dto.hasMayorDeath,
                    Year = dto.year,
                    Notes = dto.notes,





                };
                _dbContext.Battles.Add(batalla);
                _dbContext.SaveChanges();
                return Ok();

            }
            [HttpDelete("v1/battles/{id}")]
            public ActionResult<BattleDto> BorrarBatalla(int id)
            {
                var comandantes = _dbContext.BattleCommanders
        .Where(c => c.BattleId == id)
        .ToList();
                _dbContext.BattleCommanders.RemoveRange(comandantes);

                var batalla = _dbContext.Battles.FirstOrDefault(x => x.Id == id);
                if (batalla == null)
                {
                    return NotFound("la batalla no existe");
                }
                var kings = _dbContext.BattleKings
                .Where(x => x.BattleId == id)
                .ToList();
                _dbContext.BattleKings.RemoveRange(kings);
                var house = _dbContext.BattleHouses
                    .Where(x => x.BattleId == id)
                    .ToList();
                _dbContext.BattleHouses.RemoveRange(house);
                _dbContext.Battles.Remove(batalla);
                _dbContext.SaveChanges();
                return NoContent();



            }
        }
    }





