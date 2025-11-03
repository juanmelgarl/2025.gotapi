using System.Text.Json.Serialization;

namespace GotSeries.Api.Service.DTOS.REQUEST
{
    public class UpdateBattleLocationDto
    {
        [JsonPropertyName("locationId")]
        public int? Locationid { get; set; }

    }
}
