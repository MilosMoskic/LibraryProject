using FluentValidation;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Validators
{
    public class UserChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public UserChangePasswordValidator()
        {
            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).")
                .NotEqual(p => p.CurrentPassword).WithMessage("You can't have same password as current one.");
        }
    }
}
