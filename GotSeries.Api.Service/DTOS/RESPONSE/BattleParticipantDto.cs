namespace GotSeries.Api.Service.DTOS.Response
{
    public class BattleParticipantDto
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

    }

