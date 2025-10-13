using System.ComponentModel.DataAnnotations;

public class KilllistDto
{
    public string allegiance { get; set; }
    public int chapterId { get; set; }
    public int deathCategoryId { get; set; }
    public int deathCount { get; set; }
    public string deathDescription { get; set; }
    public int killerId { get; set; }
    public string locationComments { get; set; }
    public int locationId { get; set; }
    public string Season { get; set; }
    public string Victim { get; set; } = string.Empty;
    
    public string DeathType { get; set; } = string.Empty;

    public string Kingdom { get; set; } = string.Empty;
}
