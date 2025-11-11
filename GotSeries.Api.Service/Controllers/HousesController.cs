using System.Collections.Generic;
using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.DTOS.RESPONSE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HousesController() : ControllerBase
    {
        [HttpGet("/api/houses")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListadoCasas([FromQuery] PaginatedRequest paginatedRequest)
        {

            return Ok("Listado de casas");
        }

        [HttpGet("/api/houses/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ReturnHouse(int id)
        {
            return Ok($"Detalles de la casa {id}");
        }

        [HttpGet("/api/houses/{id}/battles")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ReturnBatallas(int id, PaginatedRequest paginated)
        {
            return Ok($"Batallas asociadas a la casa {id}");
        }
        [HttpGet("{houseid:int}")]
        public ActionResult ListBatallas([FromRoute] int houseid)
        {

            return Ok();   
        }

         
        
                [HttpPut("/api/houses/{id}")]
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

        [HttpGet("/api/v1/houses/{Id}")]
        public IActionResult Detallescasa()
        {
            return Ok();
        }

            }

        }
   