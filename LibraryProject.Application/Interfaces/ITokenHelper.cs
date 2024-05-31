using LibraryProject.Domain.Models;

namespace LibraryProject.Application.Interfaces
{
    public interface ITokenHelper
    {
        string CreateToken(User user);
    }
}
