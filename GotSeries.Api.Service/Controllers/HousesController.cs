using GotSeries.Api.Service.Code;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        [HttpGet("/api/v1/houses")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoCasas([FromQuery] PaginatedRequest paginatedRequest)
        {
         
            return Ok("Listado de casas"); 
        }

        [HttpGet("/api/v1/houses/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ReturnHouse(int id)
        {
            return Ok($"Detalles de la casa {id}"); 
        }

        [HttpGet("/api/v1/houses/{id}/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ReturnBatallas(int id,PaginatedRequest paginated)
        {
            return Ok($"Batallas asociadas a la casa {id}"); 
        }

        [HttpPut("/api/v1/houses/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult ModificaCasas(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"Casa {id} modificada"); 
        }
    }
}
