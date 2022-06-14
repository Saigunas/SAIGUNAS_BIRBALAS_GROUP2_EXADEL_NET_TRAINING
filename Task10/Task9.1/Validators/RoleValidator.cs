using FluentValidation;

namespace Task9._1.Validators
{
    public class RoleValidator : AbstractValidator<TaskManagementSystem.Domain.Role>
    {
        public RoleValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
}
