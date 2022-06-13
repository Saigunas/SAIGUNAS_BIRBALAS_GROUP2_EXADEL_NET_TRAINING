using FluentValidation;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Validators
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
}
