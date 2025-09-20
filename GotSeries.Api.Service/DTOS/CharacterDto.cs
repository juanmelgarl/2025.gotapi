
using System.ComponentModel.DataAnnotations;

public class CharacterDto
{
    public int id { get; set; }

    [Required(ErrorMessage = "Debes ingresar un nombre.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string name { get; set; }
    [Required(ErrorMessage = "ingresa un numero valido")]
    public int nroInSeason { get; set; }


    [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]

    public DateTime originalDateAir { get; set; }
    public int seasonId { get; set; }
    [Required(ErrorMessage = "ingresa un nombre correcto")]
    public string seasonName { get; set; }
    [Required(ErrorMessage = "ingrese una URL valida")]
    public string url { get; set; }

    public int usViewers { get; set; }
}
