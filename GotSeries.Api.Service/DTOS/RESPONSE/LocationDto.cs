using System.ComponentModel.DataAnnotations;
namespace GotSeries.Api.Service.DTOS.RESPONSE;

public class Locationdto
{
    public int id { get; set; }
    public Kingdom kingdom { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}

public class Kingdom
{
    public int id { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}
