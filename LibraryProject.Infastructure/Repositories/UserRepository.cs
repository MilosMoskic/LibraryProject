using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;
using LibraryProject.Infastructure.Context;

namespace LibraryProject.Infastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public User RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User GetLoggingUser(User user)
        {
            return _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public User GetUserById(int Id)
        {
            return _context.Users.FirstOrDefault(u => u.ID == Id);
        }

        public User GetUser(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool UniqueEmail(string email)
        {
            return _context.Users.Any(e => e.Email.ToLower() == email.ToLower());
        }
    }
}
