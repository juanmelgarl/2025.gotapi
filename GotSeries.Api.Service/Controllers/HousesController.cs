using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        [HttpGet("/api/v1/houses")]
        public IActionResult listadocasas()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/houses/{Id}")]
        public IActionResult returnhouse(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/houses/{Id}/battles")]
        public IActionResult returnbatallas(int id)
        {
            throw new NotImplementedException();

        }
        [HttpPut("/api/v1/houses/{Id}")]
        public IActionResult modificacasas(int id)
        { throw new NotImplementedException(); }



    }
}
