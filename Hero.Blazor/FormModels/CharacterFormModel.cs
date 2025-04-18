using System.ComponentModel.DataAnnotations;

namespace Hero.Blazor.FormModels
{
    public class CharacterFormModel
    {
        [Required(ErrorMessage = "Veuillez entrer un nom.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veuillez choisir une classe.")]
        public string? Job { get; set; }
    }
}
