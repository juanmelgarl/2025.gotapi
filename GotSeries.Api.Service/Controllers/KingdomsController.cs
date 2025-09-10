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
            (int id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("/api/v1/kingdoms/{Id}/locations/{\r\nlocationId}")]
        public IActionResult modificar(int id,int locationid)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/houses")]
        public IActionResult listadorcasas(int id) 
        {
            throw new NotImplementedException();
        }
        [HttpPost("/api/v1/kingdoms/{Id}/houses")]
        public IActionResult crearcasa(int id)
            { 
            throw new NotImplementedException(); 
        }
        [HttpPost("/api/v1/kingdoms/{Id}/houses/{h\r\nouseId}")]
        public IActionResult modificadatoscasa(int id,int houseid)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/battles")]
        public IActionResult listadobatallas(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/v1/kingdoms/{Id}/locations/{\r\nlocationId}/battles")]
        public IActionResult batallasenreinos(int id,int locationid)
        {
            throw new NotImplementedException();
        }


    }
}
