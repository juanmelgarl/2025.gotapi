using System.Text.Json.Serialization;

namespace GotSeries.Api.Service.Domains.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum charactertype
        {
            rey,
            comandante,
            guerrero,
            houses,
            kingdoms
        }
    }
    

