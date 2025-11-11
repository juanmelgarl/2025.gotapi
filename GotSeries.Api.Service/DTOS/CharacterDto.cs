namespace GotSeries.Api.Service.DTOS
{
    public class CharacterDto
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

    }

