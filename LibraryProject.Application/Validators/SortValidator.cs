using FluentValidation;
using LibraryProject.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Application.Validators
{
    public class SortValidator : AbstractValidator<SortDto>
    {
        public SortValidator()
        {
            RuleFor(sort => sort.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || new[] { "title", "genre", "numberofpages", "publishingyear", "author" }.Contains(value.ToLower()))
                .WithMessage("Invalid sort by value. It must be one of: title, genre, pages, year, author.")
                .When(sort => sort != null);
        }   
    }
}
