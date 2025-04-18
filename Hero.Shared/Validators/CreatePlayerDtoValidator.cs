using FluentValidation;
using Hero.Shared.Dtos;

namespace Hero.Shared.Validators
{
    public class CreatePlayerDtoValidator : AbstractValidator<CreatePlayerDto>
    {
        private static readonly string[] ValidJobNames = { "warrior", "scholar", "thief" };

        public CreatePlayerDtoValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Le nom du personnage est requis")
             .MaximumLength(10).WithMessage("12 caractères max")
             .MinimumLength(3).WithMessage("3 caractères minimum");

            RuleFor(x => x.JobName)
             .NotEmpty().WithMessage("Le personnage doit avoir une classe")
             .Must(name => ValidJobNames.Contains(name)).WithMessage("Le nom de classe doit être valide");
        }
    }
}
