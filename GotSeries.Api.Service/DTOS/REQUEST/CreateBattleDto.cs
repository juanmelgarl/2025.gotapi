using System.ComponentModel.DataAnnotations;

public class CreateBattleDto
{
    public int battleTypeId { get; set; }
    public int locationId { get; set; }
    [Required(ErrorMessage = "el nombre es requerido")]
    public string name { get; set; }
    [Range(1920, 2100, ErrorMessage = "ingrese un numero que este dentro de 1920 a 2100") ]
    public int year { get; set; }
    public bool attackerWon { get; set; }
    
    public string notes { get; set; }
    public int amountAttackerSoldiers { get; set; }
    public int amountDefenderSoldiers { get; set; }
    public bool hasMayorCapture { get; set; }
    public bool hasMayorDeath { get; set; }
    public Participant[] participants { get; set; }
}

public class ParticipantDto
{ 

    public string participationType { get; set; }
    public int participantId { get; set; }
    public bool isAttacker { get; set; }
}
