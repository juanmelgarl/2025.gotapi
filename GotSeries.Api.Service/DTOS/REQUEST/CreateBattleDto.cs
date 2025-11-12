namespace GotSeries.Api.Service.DTOS.Request
{
  
        public class CreateBattleDto
        {
            public int battleTypeId { get; set; }
            public int locationId { get; set; }
            public string name { get; set; }
            public int year { get; set; }
            public bool attackerWon { get; set; }
            public string notes { get; set; }
            public int amountAttackerSoldiers { get; set; }
            public int amountDefenderSoldiers { get; set; }
            public bool hasMayorCapture { get; set; }
            public bool hasMayorDeath { get; set; }
            public Participant[] participants { get; set; }
        }

        public class Participant
        {
            public string participationType { get; set; }
            public int participantId { get; set; }
            public bool isAttacker { get; set; }
        }

    }

