using System.ComponentModel.DataAnnotations;

public class CreateHouseDto
{
    [Required(ErrorMessage = "ingrese una url valida")]
    public string coatOfArmsUrl { get; set; }
    [Required(ErrorMessage = "ingrese un nombre valido")]
    public string name { get; set; }
    public string summary { get; set; }
    public string url { get; set; }
}
