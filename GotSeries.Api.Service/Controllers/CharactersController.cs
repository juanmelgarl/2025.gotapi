using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        [HttpGet("/api/v1/characters/{characterTyp\r\ne}")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPut("/api/v1/characters/{id}")]
        public IActionResult modificaparticipante(int? id)
        {
            if (id != null)
            {
                return Ok($"participante eliminado correctamente");
            }
            else
                return BadRequest();
        }
        [HttpPatch("/api/v1/characters/{Id}")]
        public IActionResult cambiartipopersonaje(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("/api/v1/characters/{id}/death")]
        public IActionResult registerdeaths(int id)
        { 
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/characters/{Id}/kills")]
        public IActionResult registerkills(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/characters/{Id}/death")]
        public IActionResult returnkills(int id)
        {
            throw new NotImplementedException();
        }
       
    

    }
}
