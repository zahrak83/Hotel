using Hotel.Dtos;
using Hotel.Entities;

namespace Hotel.Interface.IRepositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        User? AuthenticateUser(string username, string password);
        User? Add(User user);
        bool IsUsernameTaken(string username);
        List<User> GetAll();
    }
}

