using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GotSeries.Api.Service.Code;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GotSeries.Api.Service.Infrastructure.Data;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController(GotDbContext dbContext) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public ActionResult<Battledto> BuscarporID([FromRoute] int id)
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
        
       

        
        [HttpGet("/v1/battles/")]
        public ActionResult<List<BattlelistDTO>> buscarbatalla()
        {
            var battles = dbContext.Battles
                .Include(x => x.BattleType)
                .Include(c => c.Location)
                .ThenInclude(x => x.Kingdom)
               .Select(b => new BattlelistDTO


               {
                   id = b.Id,
                   name = b.Name,
                   amountAttackerSoldiers = b.AmountAttackerSoldiers,
                   amountDefenderSoldiers = b.AmountDefenderSoldiers,
                   hasMayorCapture = b.HasMayorCapture,
                   hasMayorDeath = b.HasMayorDeath,
                   year = b.Year,
                   








               });
               
                
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
        public async Task<IActionResult> CreateBatalla([FromBody] CreateBattleDto createBattle)
        {
           
            return Ok();
        }
        [HttpDelete("v1/battles/{id}")]
        public ActionResult<Battledto> BorrarBatalla(int id)
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

