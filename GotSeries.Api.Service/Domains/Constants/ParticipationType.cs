using System.Text.Json.Serialization;

namespace GotSeries.Api.Service.Domains.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum charactertype 
        {
            Rey,
            Comandante,
            Guerrero,
            Houses,
            Kingdoms
        }
    }
    

