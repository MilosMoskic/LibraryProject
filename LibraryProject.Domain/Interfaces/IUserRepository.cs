using LibraryProject.Domain.Models;

namespace LibraryProject.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User RegisterUser(User user);
        User UpdateUser(User user);
        User GetLoggingUser(User user);
        User GetUser(string email);
        User GetUserById(int Id);
        bool UniqueEmail(string email);
    }
}
