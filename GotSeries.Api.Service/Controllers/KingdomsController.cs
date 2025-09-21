using GotSeries.Api.Service.Code;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KingdomsController : ControllerBase
    {
        [HttpGet("/api/v1/kingdoms")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoReinos(PaginatedRequest paginatedRequest)
        {
            return Ok("Listado de reinos"); 
        }

        
        [HttpGet("/api/v1/kingdoms/{id}/locations")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoUbicaciones(int id,PaginatedRequest paginatedRequest)
        {
            return Ok($"Ubicaciones del reino {id}"); 
        }

        [HttpPut("/api/v1/kingdoms/{id}/locations/{locationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult ModificarUbicacion(int id, int locationId)
            
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"Ubicación {locationId} modificada en reino {id}");
        }

        [HttpGet("/api/v1/kingdoms/{id}/houses")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoCasas(int id,PaginatedRequest paginated)
        {
            return Ok($"Casas del reino {id}"); 
        }

        [HttpPost("/api/v1/kingdoms/{id}/houses")]
        public IActionResult CrearCasa(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"Casa creada en reino {id}");
        }

        [HttpPost("/api/v1/kingdoms/{id}/houses/{houseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult ModificaDatosCasa(int id, int houseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"Datos de casa {houseId} modificados en reino {id}"); 
        }

        [HttpGet("/api/v1/kingdoms/{id}/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoBatallas(int id, PaginatedRequest paginated)
        {
            return Ok($"Batallas en reino {id}"); 
        }

        [HttpGet("/api/v1/kingdoms/{id}/locations/{locationId}/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult BatallasEnUbicacion(int id, int locationId)
        {
            return Ok($"Batallas en ubicación {locationId} del reino {id}");
        }
    }
}
