using GotSeries.Api.Service.Code;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KingdomsController : ControllerBase
    {
        [HttpGet("/api/v1/kingdoms")]
        public IActionResult ListadoReinos(PaginatedRequest paginatedRequest)
        {
            return Ok("Listado de reinos"); // Temporal
        }

        [HttpGet("/api/v1/kingdoms/{id}/locations")]
        public IActionResult ListadoUbicaciones(int id,PaginatedRequest paginatedRequest)
        {
            return Ok($"Ubicaciones del reino {id}"); // Temporal
        }

        [HttpPut("/api/v1/kingdoms/{id}/locations/{locationId}")]
        public IActionResult ModificarUbicacion(int id, int locationId)
        {
            return Ok($"Ubicación {locationId} modificada en reino {id}");
        }

        [HttpGet("/api/v1/kingdoms/{id}/houses")]
        public IActionResult ListadoCasas(int id,PaginatedRequest paginated)
        {
            return Ok($"Casas del reino {id}"); 
        }

        [HttpPost("/api/v1/kingdoms/{id}/houses")]
        public IActionResult CrearCasa(int id)
        {
            return Ok($"Casa creada en reino {id}");
        }

        [HttpPost("/api/v1/kingdoms/{id}/houses/{houseId}")]
        public IActionResult ModificaDatosCasa(int id, int houseId)
        {
            return Ok($"Datos de casa {houseId} modificados en reino {id}"); 
        }

        [HttpGet("/api/v1/kingdoms/{id}/battles")]
        public IActionResult ListadoBatallas(int id, PaginatedRequest paginated)
        {
            return Ok($"Batallas en reino {id}"); 
        }

        [HttpGet("/api/v1/kingdoms/{id}/locations/{locationId}/battles")]
        public IActionResult BatallasEnUbicacion(int id, int locationId)
        {
            return Ok($"Batallas en ubicación {locationId} del reino {id}");
        }
    }
}
