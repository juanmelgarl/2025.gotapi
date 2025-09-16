using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        [HttpGet("/api/v1/houses")]
        public IActionResult ListadoCasas()
        {
            return Ok("Listado de casas"); 
        }

        [HttpGet("/api/v1/houses/{id}")]
        public IActionResult ReturnHouse(int id)
        {
            return Ok($"Detalles de la casa {id}"); 
        }

        [HttpGet("/api/v1/houses/{id}/battles")]
        public IActionResult ReturnBatallas(int id)
        {
            return Ok($"Batallas asociadas a la casa {id}"); 
        }

        [HttpPut("/api/v1/houses/{id}")]
        public IActionResult ModificaCasas(int id)
        {
            return Ok($"Casa {id} modificada"); 
        }
    }
}
