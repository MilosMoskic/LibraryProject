using FluentValidation;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Validators
{
    public class UserUpdateValidator : AbstractValidator<UpdateUserInfoDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(user => user.Username)
                .NotNull().WithMessage("Your username cannot be null.")
                .NotEmpty().WithMessage("Your username cannot be emtpy.")
                .MinimumLength(6).WithMessage("Your username must have at least 6 characters.");
        }
    }
}
