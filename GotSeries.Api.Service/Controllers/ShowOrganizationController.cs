using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowOrganizationController : ControllerBase
    {
        [HttpGet("/api/v1/show/seasons/")]
        public IActionResult listadotemporadas()
        {
            throw new NotImplementedException();

        }
        [HttpGet("/api/v1/show/seasons/{id}/chapt\r\ner")]
        public IActionResult listarcapitulos(int id) {
            throw new NotImplementedException(); }
        [HttpGet("/api/v1/show/seasons/{id}/chapt\r\ner/{chapterId}")]
        public IActionResult detallecapitulo(int id,int chapterid)
            { throw new NotImplementedException(); }
        [HttpGet("/api/v1/show/seasons/{id}/chapt\r\ner/{chapterId}/deaths")]
        public IActionResult listarmuertes(int id,int chapterid)
        { throw new NotImplementedException(); }

    }
}
