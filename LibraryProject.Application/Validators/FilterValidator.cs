using FluentValidation;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Validators
{
    public class FilterValidator : AbstractValidator<FilterDto>
    {
        public FilterValidator()
        {
            RuleFor(filter => filter.Title)
                    .MaximumLength(40)
                    .WithMessage("Maximum length of the title is 40 characters.")
                    .When(filter => filter != null);
            RuleFor(filter => filter.Genre)
                    .MaximumLength(20).WithMessage("Maximum length of the genre is 20 characters.")
                    .When(filter => filter != null);
            RuleFor(filter => filter.MinNumberOfPages)
                    .InclusiveBetween(0, int.MaxValue)
                    .When(filter => filter != null);
            RuleFor(filter => filter.MaxNumberOfPages)
                    .InclusiveBetween(0, int.MaxValue)
                    .When(filter => filter.MinNumberOfPages > 0)
                    .Must((filter, maxPages) => maxPages >= filter.MinNumberOfPages)
                    .WithMessage("Maximum number of pages must be greater than or equal to minimum number of pages.")
                    .When(filter => filter.MaxNumberOfPages.HasValue && filter.MinNumberOfPages.HasValue)
                    .When(filter => filter != null);
            RuleFor(filter => filter.PublishingYearMax)
                    .InclusiveBetween(1, DateTime.Now.Year)
                    .WithMessage("Year must be between 1 and " + DateTime.Now.Year)
                    .NotEqual(0).WithMessage("Publishing year 0 doesn't exist.")
                    .When(filter => filter.PublishingYearMin > 0)
                    .Must((filter, maxYear) => maxYear >= filter.PublishingYearMin)
                    .WithMessage("Maximum year must be greater than or equal to minimum year.")
                    .When(filter => filter.PublishingYearMax.HasValue && filter.PublishingYearMin.HasValue)
                    .When(filter => filter != null);
            RuleFor(filter => filter.PublishingYearMin)
                    .InclusiveBetween(1, DateTime.Now.Year)
                    .WithMessage("Year must be between 1 and " + DateTime.Now.Year)
                    .NotEqual(0).WithMessage("Publishing year 0 doesn't exist.")
                    .When(filter => filter != null);
            RuleFor(filter => filter.Author)
                    .MaximumLength(20).WithMessage("Maximum length of the author name is 20 characters.")
                    .When(filter => filter != null);
        }

    }
}
