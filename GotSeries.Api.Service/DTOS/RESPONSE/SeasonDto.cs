using System.ComponentModel.DataAnnotations;

public class SeasonDto
{
    public int id { get; set; }

    [Required(ErrorMessage = "Debes ingresar un nombre.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string name { get; set; }
    [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
    public int year { get; set; }
}
