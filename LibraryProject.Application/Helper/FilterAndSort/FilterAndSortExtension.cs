using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Application.Helper.FilterAndSort
{
    public static class FilterAndSortExtension
    {
        public static IQueryable<Book> Filter(this IQueryable<Book> filteredBooks, FilterDto filter)
        {
            if (filter == null)
            {
                return filteredBooks;
            }

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                filteredBooks = filteredBooks.Where(b => b.Title.ToUpper().Contains(filter.Title.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filter.Genre))
            {
                filteredBooks = filteredBooks.Where(b => b.Genre.ToUpper().Contains(filter.Genre.ToUpper()));
            }

            if (filter.MinNumberOfPages != null)
            {
                filteredBooks = filteredBooks.Where(b => b.NumberOfPages >= filter.MinNumberOfPages);
            }

            if (filter.MaxNumberOfPages != null)
            {
                filteredBooks = filteredBooks.Where(b => b.NumberOfPages <= filter.MaxNumberOfPages);
            }

            if (filter.PublishingYearMin != null)
            {
                filteredBooks = filteredBooks.Where(b => b.PublishingYear >= filter.PublishingYearMin);
            }

            if (filter.PublishingYearMax != null)
            {
                filteredBooks = filteredBooks.Where(b => b.PublishingYear <= filter.PublishingYearMax);
            }

            if (!string.IsNullOrWhiteSpace(filter.Author))
            {
                filteredBooks = filteredBooks.Where(b => b.Authors.Any(a =>
                    a.FirstName.ToUpper().Contains(filter.Author.ToUpper()) ||
                    a.LastName.ToUpper().Contains(filter.Author.ToUpper())));
            }

            return filteredBooks;
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, SortDto sortDto)
        {
            if (sortDto == null)
            {
                return books;
            }

            Expression<Func<Book, object>> keySelector = ExtractSortByParameter(sortDto);

            if (sortDto.IsDescending)
            {
                books = books.OrderByDescending(keySelector);
            }
            else
            {
                books = books.OrderBy(keySelector);
            }

            return books;
        }

        public static Expression<Func<Book, object>> ExtractSortByParameter(SortDto sortDto)
        {
            if (string.IsNullOrEmpty(sortDto.SortBy))
            {
                return book => book.Title;
            }

            return sortDto.SortBy.ToLower() switch
            {
                "title" => book => book.Title,
                "publishingyear" => book => book.PublishingYear,
                "numberofpages" => book => book.NumberOfPages,
                "genre" => book => book.Genre,
                "author" => book => book.Authors.First().FirstName,
                _ => book => book.Title
            };
        }
    }
}
