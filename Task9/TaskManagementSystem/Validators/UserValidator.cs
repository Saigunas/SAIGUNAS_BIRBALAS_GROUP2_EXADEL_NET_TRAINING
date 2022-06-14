using FluentValidation;

namespace TaskManagementSystem.Validators
{
    public class UserValidator : AbstractValidator<TaskManagementSystem.Model.User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.RoleID).NotNull().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Password).Must(pass => { return pass.Length > 6; }).WithMessage("Password must be longer than 6 characters");
        }
    }
}
