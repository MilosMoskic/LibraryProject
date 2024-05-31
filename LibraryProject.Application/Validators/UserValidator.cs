using FluentValidation;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Interfaces;

namespace LibraryProject.Application.Validators
{
    public class UserValidator : AbstractValidator<RegistrationUserDto>
    {
        IUserRepository _repository;
        public UserValidator(IUserRepository repository)
        {
            _repository = repository;

            RuleFor(user => user.Username)
                .NotNull().WithMessage("Your username cannot be null.")
                .NotEmpty().WithMessage("Your username cannot be emtpy.")
                .MinimumLength(6).WithMessage("Your username must have at least 6 characters.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

            RuleFor(user => user.Email).NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email is required.")
                .Must(e => !_repository.UniqueEmail(e)).WithMessage("This email already exists.");
        }
    }
}
