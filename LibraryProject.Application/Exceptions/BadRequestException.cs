using System.Net;

namespace LibraryProject.Application.Exceptions
{
    public class BadRequestException : BaseCustomException
    {
        public BadRequestException(string errorMessage) : base(errorMessage, HttpStatusCode.BadRequest) { }
    }
}
