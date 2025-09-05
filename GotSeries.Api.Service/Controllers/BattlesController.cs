using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        [HttpGet("listar")]
        public IActionResult ListarBatallas()
        {
            return Ok("soy una batalla");
        }

        [HttpDelete("delete/{battleid}")]
        public IActionResult Borrar(int battleid)
        {
            if (battleid < 10)
            {
                return Ok("batalla eliminada");
            }
            else
            {
                return BadRequest("error");
            }
        }
        //api//
    }
}
