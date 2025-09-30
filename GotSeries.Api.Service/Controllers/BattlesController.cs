using GotSeries.Api.Service.Code;
using GotSeries.Api.Service.Domains.Constants;
using GotSeries.Api.Service.DTOS.REQUEST;
using GotSeries.Api.Service.DTOS.RESPONSE;
using GotSeries.Api.Service.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/v1/battles")]
[ApiController]
public class BattlesController : ControllerBase
{
    private readonly GotDbContext _dbcontext;
    public BattlesController(GotDbContext dbContext) => _dbcontext = dbContext;

    [HttpGet]
    public ActionResult<List<personaje>> ListarBatallas([FromQuery] PaginatedRequest paginatedRequest)
        => Ok(new List<personaje>());

    [HttpGet("{id}")]
    public async Task<IActionResult> LeerBatalla([FromRoute] int id, [FromQuery] charactertype charactertype)
    {
        var battle = await _dbcontext.Battles.FirstOrDefaultAsync(b => b.Id == id);
        return battle != null ? Ok(battle) : NotFound();
    }

    [HttpGet("{id}/participation")]
    public IActionResult ListaCasas([FromRoute] int id, [FromQuery] charactertype tipoPersonaje, [FromQuery] PaginatedRequest paginatedRequest)
        => Ok($"Casas en batalla {id}");

    [HttpPost]
    public IActionResult CrearBatalla([FromBody] battledto batalla)
        => ModelState.IsValid ? Ok("Batalla creada") : BadRequest(ModelState);

    [HttpPost("{id}/participation")]
    public IActionResult AgregarParticipante([FromRoute] int id, [FromBody] ParticipantDto participante)
        => ModelState.IsValid ? Ok($"Nuevo participante agregado a batalla {id}") : BadRequest(ModelState);

    [HttpPut("{id}/participation/{participationType}/{participantId}")]
    public IActionResult ModificarParticipante([FromRoute] int id, [FromRoute] string participationType, [FromRoute] int participantId, [FromBody] AddParticipationDto participante)
        => ModelState.IsValid ? Ok(new { id, participationType, participantId }) : BadRequest(ModelState);

    [HttpDelete("{id}/participation/{participationType}/{participantId}")]
    public IActionResult EliminarParticipante([FromRoute] int id, [FromRoute] string participationType, [FromRoute] int participantId)
        => Ok($"Participante {participantId} eliminado de batalla {id}");
}
