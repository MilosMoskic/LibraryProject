using FluentValidation;
using LibraryProject.Application.Enums;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title)
                .NotNull().WithMessage("Books title cannot be null.")
                .NotEmpty().WithMessage("Books title cannot be emtpy.");
            RuleFor(book => book.ISBN).SetValidator(new ISBNValidator<BookDto>());
            RuleFor(book => book.NumberOfPages)
                .NotNull().WithMessage("Number of pages be null.")
                .NotEmpty().WithMessage("Number of pages cannot cannot be emtpy.")
                .GreaterThanOrEqualTo(0).WithMessage("Number of pages must not be negative.");
            RuleFor(book => book.Genre)
                .IsEnumName(typeof(BookGenres.Genre), caseSensitive: false)
                .WithMessage("Invalid genre. Please provide a valid genre.");
            RuleFor(book => book.PublishingYear)
                .NotNull().WithMessage("Publishing year cannot be null.")
                .NotEmpty().WithMessage("Publishing year cannot cannot be emtpy.")
                .NotEqual(0).WithMessage("Publishing year 0 doesn't exist.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("The year cannot be greater than the current year.");
            RuleFor(book => book.TotalCopies)
                .NotNull().WithMessage("Total copies cannot be null.")
                .NotEmpty().WithMessage("Total copies cannot cannot be emtpy.")
                .GreaterThanOrEqualTo(0).WithMessage("Total copies must not be negative.");
        }
    }
}
