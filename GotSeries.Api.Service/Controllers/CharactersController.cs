using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.Domains.Constants;
using GotSeries.Api.Service.DTOS.Response;

using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
       
      
        [HttpGet("/api/v1/characters/{characterTyp\r\ne}")]
        public IActionResult Listarpersonajes()
        {
            return Ok();
        }
        [HttpPut("/api/v1/characters/{id}")]
        public IActionResult Modificarpersonaje()
        {return Ok();

        }
       

        [HttpPut("/api/characters/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

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

        [HttpPatch("/api/characters/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult CambiarTipoPersonaje(int id)
        {
            return Ok($"Tipo de personaje del ID {id} actualizado"); 
        }

        
        [HttpPost("/api/characters/{id}/death")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult RegistrarMuerte(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"Muerte registrada para personaje {id}"); 
        }

       
        [HttpGet("/api/characters/{id}/kills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerVictimas(int id)
        {
            return Ok($"Victimas del personaje {id}");
        }

        [HttpGet("/api/characters/{id}/death")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ObtenerMuerte(int id)
        {
            return Ok($"Detalles de la muerte del personaje {id}");
        }

    }
}
