using FluentValidation;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator()
        {
            RuleFor(review => review.Rating)
                .NotNull().WithMessage("Rating cannot be null.")
                .InclusiveBetween(1, 10).WithMessage("Rating must be between 1 and 10.");
            RuleFor(review => review.Description)
                .NotNull().WithMessage("Description cannot be null.")
                .MaximumLength(200).WithMessage("Maximum length for description is 200 characters");
        }
    }
    
}
