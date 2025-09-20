using System.ComponentModel.DataAnnotations;

public class deathinfodto
{
    public string allegiance { get; set; }
    public Chapter chapter { get; set; }
    public string deathCategory { get; set; }
    public int deathCategoryId { get; set; }
    public int deathCount { get; set; }
    public string deathDescription { get; set; }
    public int id { get; set; }
    public Killed killed { get; set; }
    public Killer killer { get; set; }
    public Location location { get; set; }
    public string locationComments { get; set; }
    public string reason { get; set; }
}

public class Chapter
{
    public int id { get; set; }
    public string name { get; set; }
    public int nroInSeason { get; set; }
    public DateTime originalDateAir { get; set; }
    public int seasonId { get; set; }
    public string seasonName { get; set; }
    public string url { get; set; }
    public int usViewers { get; set; }
}

public class Killed
{
    public int id { get; set; }
    public bool isCommander { get; set; }
    public bool isDeath { get; set; }
    public bool isGeneric { get; set; }
    public bool isHumman { get; set; }
    public bool isKing { get; set; }
    public bool isRoyalty { get; set; }
    public string name { get; set; }
}

public class Killer
{
    public int id { get; set; }
    public bool isCommander { get; set; }
    public bool isDeath { get; set; }
    public bool isGeneric { get; set; }
    public bool isHumman { get; set; }
    public bool isKing { get; set; }
    public bool isRoyalty { get; set; }
    public string name { get; set; }
}
