

namespace GotSeries.Api.Service.DTOS.Request
{
    public class AddParticipantToBattleDto
    {
        public string participationType { get; set; }
        public int participantId { get; set; }
        public bool isAttacker { get; set; }
    }
}
