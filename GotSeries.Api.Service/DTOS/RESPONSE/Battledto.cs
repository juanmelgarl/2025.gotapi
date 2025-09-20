
public class battledto
{
    public int amountAttackerSoldiers { get; set; }
    public int amountDefenderSoldiers { get; set; }
    public bool attackerWon { get; set; }
    public string battleType { get; set; }
    public int battleTypeId { get; set; }
    public bool hasMayorCapture { get; set; }
    public bool hasMayorDeath { get; set; }
    public int id { get; set; }
    public Location location { get; set; }
    public string name { get; set; }
    public string notes { get; set; }
    public Participant[] participants { get; set; }
    public int year { get; set; }
}



public class Participant
{
    public bool isAttacker { get; set; }
    public int participationType { get; set; }
    public int id { get; set; }
    public bool isCommander { get; set; }
    public bool isDeath { get; set; }
    public bool isGeneric { get; set; }
    public bool isHumman { get; set; }
    public bool isKing { get; set; }
    public bool isRoyalty { get; set; }
    public string name { get; set; }
}
