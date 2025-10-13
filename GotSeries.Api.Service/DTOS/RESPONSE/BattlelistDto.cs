using System.ComponentModel.DataAnnotations;
namespace GotSeries.Api.Service.DTOS.RESPONSE;
public class BattlelistDto
{
    public int amountAttackerSoldiers { get; set; }
    public int amountDefenderSoldiers { get; set; }
    public string? battleType { get; set; }
    public int battleTypeId { get; set; }
    public bool hasMayorCapture { get; set; }
    public bool hasMayorDeath { get; set; }
    public int id { get; set; }
    public Location? location { get; set; }
    public string name { get; set; }
    public int year { get; set; }
 
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Location { get; set; } 
        public string Kingdom { get; set; }
        public string Type { get; set; } 
    }


