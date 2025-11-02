using System.ComponentModel.DataAnnotations;

public class UpdateLocationDto
{
    public int? Id { get; set; }
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}
