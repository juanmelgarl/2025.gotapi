using System.ComponentModel.DataAnnotations;
namespace GotSeries.Api.Service.DTOS.RESPONSE;

public class Rootobject
{
    public string coatOfArmsUrl { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
    public Battle[] battles { get; set; }
}

public class Battle
{
    public bool isAttacker { get; set; }
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
}

public class Location
{
    public int id { get; set; }
    public Kingdom kingdom { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}

public class Kingdomdto
{
    public int id { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}
