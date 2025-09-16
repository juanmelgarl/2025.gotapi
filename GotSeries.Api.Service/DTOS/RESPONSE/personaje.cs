using GotSeries.Api.Service.Domains.Constants;
namespace GotSeries.Api.Service.DTOS.RESPONSE

{
    public class personaje
{
    public required int id { get; set; }
    public string nombre { get; set; }
    public required string alias { get; set; }
    public required charactertype charactertype { get; set; }

    public int houseid { get; set; }
    public string namehouse { get; set; }
}
}