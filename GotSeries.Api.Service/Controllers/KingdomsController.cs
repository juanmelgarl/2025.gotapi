using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KingdomsController : ControllerBase
    {
        [HttpGet("/api/v1/kingdoms")]
        public IActionResult listadoreinos()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/locations")]
        public IActionResult listadoubicaciones
            () { throw new NotImplementedException(); }
        [HttpPut("/api/v1/kingdoms/{Id}/locations/{\r\nlocationId}")]
        public IActionResult modificar()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/houses")]
        public IActionResult listadorcasas() { throw new NotImplementedException(); }
        [HttpPost("/api/v1/kingdoms/{Id}/houses")]
        public IActionResult crearcasa()
            { throw new NotImplementedException(); }
        [HttpPost("/api/v1/kingdoms/{Id}/houses/{h\r\nouseId}")]
        public IActionResult modificadatoscasa()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/battles")]
        public IActionResult listadobatallas()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/locations/{\r\nlocationId}/battles")]
        public IActionResult batallasenreinos()
        {
            throw new NotImplementedException();
        }


    }
}
