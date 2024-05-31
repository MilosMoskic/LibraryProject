using FluentValidation;
using LibraryProject.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Application.Validators
{
    public class FilterAndSortValidator : AbstractValidator<FilterAndSortDto>
    {
        public FilterAndSortValidator()
        {
            RuleFor(fs => fs.FilterDto).SetValidator(new FilterValidator());
            RuleFor(fs => fs.SortDto).SetValidator(new SortValidator());
        }
    }
}
