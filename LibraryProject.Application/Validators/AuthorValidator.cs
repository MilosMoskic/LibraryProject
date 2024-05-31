using FluentValidation;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.FirstName)
                .NotNull().WithMessage("Authors firstname cannot be null.")
                .NotEmpty().WithMessage("Authors firstname cannot be emtpy.");
            RuleFor(author => author.LastName)
                .NotNull().WithMessage("Authors lastname cannot be null.")
                .NotEmpty().WithMessage("Authors lastname cannot be emtpy.");
            RuleFor(author => author.YearOfBirth)
                .NotNull().WithMessage("Year cannot be null.")
                .NotEmpty().WithMessage("Year cannot cannot be emtpy.")
                .NotEqual(0).WithMessage("Year 0 doesn't exist.")
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("The year cannot be greater than the current year.");
        }
    }
}
