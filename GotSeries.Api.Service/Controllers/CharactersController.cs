using GotSeries.Api.Service.Domains.Constants;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        [HttpGet("/api/v1/characters")]
        public IActionResult Get([FromQuery] charactertype tipoPersonaje)
        {
         
            return Ok(new { tipoPersonaje }); 
        }

        // PUT /api/v1/characters/5
        [HttpPut("/api/v1/characters/{id}")]
        public IActionResult ModificarParticipante(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != null)
                return Ok($"Participante {id} modificado correctamente");
            else
                return BadRequest("ID inválido");
        }

        [HttpPatch("/api/v1/characters/{id}")]
        public IActionResult CambiarTipoPersonaje(int id)
        {
            return Ok($"Tipo de personaje del ID {id} actualizado"); 
        }

        
        [HttpPost("/api/v1/characters/{id}/death")]
        public IActionResult RegistrarMuerte(int id)
        {
            return Ok($"Muerte registrada para personaje {id}"); 
        }

       
        [HttpGet("/api/v1/characters/{id}/kills")]
        public IActionResult ObtenerVictimas(int id)
        {
            return Ok($"Victimas del personaje {id}");
        }

        [HttpGet("/api/v1/characters/{id}/death")]
        public IActionResult ObtenerMuerte(int id)
        {
            return Ok($"Detalles de la muerte del personaje {id}");
        }
    }
}
