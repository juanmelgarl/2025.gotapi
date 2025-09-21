using GotSeries.Api.Service.Code;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowOrganizationController : ControllerBase
    {
        [HttpGet("/api/v1/show/seasons")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoTemporadas(PaginatedRequest paginated)
        {
            return Ok("Listado de temporadas");
        }

        [HttpGet("/api/v1/show/seasons/{id}/chapter")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListarCapitulos(int id, PaginatedRequest paginated)
        {
            return Ok($"Capítulos de la temporada {id}"); 
        }

        [HttpGet("/api/v1/show/seasons/{id}/chapter/{chapterId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DetalleCapitulo(int id, int chapterId)
        {
            return Ok($"Detalles del capítulo {chapterId} de la temporada {id}"); 
        }

        [HttpGet("/api/v1/show/seasons/{id}/chapter/{chapterId}/deaths")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListarMuertes(int id, int chapterId,PaginatedRequest paginatedRequest)
        {
            return Ok($"Muertes en capítulo {chapterId} de la temporada {id}"); 
        }
    }
}
