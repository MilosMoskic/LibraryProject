using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Application.Helper.Pagination
{
    public class PaginatedHttpGetAttribute : HttpGetAttribute
    {
        public PaginatedHttpGetAttribute(string name)
        {
            Name = name;
        }
    }
}
