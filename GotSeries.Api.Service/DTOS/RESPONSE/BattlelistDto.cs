using System.ComponentModel.DataAnnotations;
namespace GotSeries.Api.Service.DTOS.RESPONSE;

public class BattlelistDTO
{
    public int amountAttackerSoldiers { get; set; }
    public int amountDefenderSoldiers { get; set; }
    public string battleType { get; set; }
    public int battleTypeId { get; set; }
    public bool hasMayorCapture { get; set; }
    public bool hasMayorDeath { get; set; }
    public int id { get; set; }
    public Location location { get; set; }
    public string name { get; set; }
    public int year { get; set; }
    public string kingdom { get; internal set; }
}

public class LocationD
{
    public int id { get; set; }
    public Kingdom kingdom { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}

public class Kingdom
{
    public int id { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}

