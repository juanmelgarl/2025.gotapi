using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowOrganizationController : ControllerBase
    {
        [HttpGet("/api/v1/show/seasons")]
        public IActionResult ListadoTemporadas()
        {
            return Ok("Listado de temporadas");
        }

        [HttpGet("/api/v1/show/seasons/{id}/chapter")]
        public IActionResult ListarCapitulos(int id)
        {
            return Ok($"Capítulos de la temporada {id}"); 
        }

        [HttpGet("/api/v1/show/seasons/{id}/chapter/{chapterId}")]
        public IActionResult DetalleCapitulo(int id, int chapterId)
        {
            return Ok($"Detalles del capítulo {chapterId} de la temporada {id}"); 
        }

        [HttpGet("/api/v1/show/seasons/{id}/chapter/{chapterId}/deaths")]
        public IActionResult ListarMuertes(int id, int chapterId)
        {
            return Ok($"Muertes en capítulo {chapterId} de la temporada {id}"); 
        }
    }
}
