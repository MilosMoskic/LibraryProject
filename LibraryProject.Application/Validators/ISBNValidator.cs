using FluentValidation;
using FluentValidation.Validators;

namespace LibraryProject.Application.Validators
{
    public class ISBNValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "ISBNValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return IsValidIsbn(value);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "Not valid ISBN";

        private bool IsValidIsbn(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return false;

            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length == 10)
                return IsValidIsbn10(isbn);

            if (isbn.Length == 13)
                return IsValidIsbn13(isbn);

            return false;
        }

        private bool IsValidIsbn10(string isbn10)
        {
            if (isbn10.Length != 10 || !isbn10.All(c => char.IsDigit(c) || c == 'X'))
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(isbn10[i]))
                    return false;

                sum += (isbn10[i] - '0') * (10 - i);
            }

            char checksum = isbn10[9];
            sum += checksum == 'X' ? 10 : checksum - '0';

            return sum % 11 == 0;
        }

        private bool IsValidIsbn13(string isbn13)
        {
            if (isbn13.Length != 13 || !isbn13.All(char.IsDigit))
                return false;

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = isbn13[i] - '0';
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int checksum = 10 - (sum % 10);
            if (checksum == 10) checksum = 0;

            return checksum == (isbn13[12] - '0');
        }
    }
}