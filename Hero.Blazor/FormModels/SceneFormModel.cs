using System.ComponentModel.DataAnnotations;

namespace Hero.Blazor.FormModels
{
    public class SceneFormModel
    {
        [Required(ErrorMessage = "La scène doit avoir un nom")]
        [MinLengthAttribute(3, ErrorMessage = "Le nom de la scène doit avoir au moins 3 caractères")]
        [MaxLengthAttribute(12, ErrorMessage = "Le nom de la scène doit avoir au moins 3 caractères")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "La scène doit avoir une description")]
        public string Description { get; set; } = string.Empty;
    }
}
