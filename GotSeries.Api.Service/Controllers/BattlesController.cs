using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GotSeries.Api.Service.Code;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GotSeries.Api.Service.Infrastructure.Data;
using GotSeries.Api.Service.DTOS.Response;

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
            return Ok();

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
        public ActionResult Añadirparticipante()
        {
            return
                Ok();
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
        [HttpGet("/api/v1/battles/{id}/participation")]
        public ActionResult Listadocasas(int id)
        {
            return Ok();
        }



    }
}



