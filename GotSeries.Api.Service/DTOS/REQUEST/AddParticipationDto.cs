using System.ComponentModel.DataAnnotations;

public class AddParticipationDto
{
    [Required(ErrorMessage = "Ingrese el tipo de personaje")]
    public string participationType { get; set; }
    public int participantId { get; set; }
    public bool isAttacker { get; set; }
}
