using FluentValidation;
using Hero.Shared.Models;

namespace Hero.Shared.Validators
{
    internal class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Le nom est requis")
            .MaximumLength(10).WithMessage("10 caractères max");

            RuleFor(x => x.Job)
                .NotEmpty().WithMessage("La classe est requise");
        }
    }
}
