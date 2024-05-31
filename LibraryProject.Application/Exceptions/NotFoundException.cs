using System.Net;

namespace LibraryProject.Application.Exceptions
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException(string errorMessage) : base(errorMessage, HttpStatusCode.NotFound) { }
    }
}
