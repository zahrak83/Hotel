using Hotel.Dtos;
using Hotel.Entities;
using Hotel.Interface.IRepositories;

namespace Hotel.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public User? Add(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public User? AuthenticateUser(string username, string password)
        {
            return _appDbContext.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User? GetByUsername(string username)
        {
            return _appDbContext.Users
                .FirstOrDefault(u => u.Username == username);

        }

        public bool IsUsernameTaken(string username)
        {
            return _appDbContext.Users.Any(u => u.Username == username);
        }

        public List<User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }
    }
}
