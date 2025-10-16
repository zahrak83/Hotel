using Hotel.Dtos;
using Hotel.Entities;
using Hotel.Infrastructure.Repositories;
using Hotel.Interface.IRepositories;
using Hotel.Interface.IServices;

namespace Hotel.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public GetUserDto Register(UserRegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Password cannot be empty.");

            if (_userRepository.IsUsernameTaken(dto.Username))
                throw new InvalidOperationException("Username already exists.");

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = dto.Role,
                CreatedAt = DateTime.Now
            };

            var createdUser = _userRepository.Add(user);

            return new GetUserDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Role = createdUser.Role.ToString(),
                CreatedAt = createdUser.CreatedAt
            };
        }

        public GetUserDto Login(UserLoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Username or password cannot be empty.");

            var user = _userRepository.GetByUsername(dto.Username);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            if (user.Password != dto.Password)
                throw new InvalidOperationException("Invalid password.");

            return new GetUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString(),
                CreatedAt = user.CreatedAt
            };
        }

        public List<GetUserDto> GetAll()
        {
            var users = _userRepository.GetAll();

            return users.Select(u => new GetUserDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role.ToString(),
                CreatedAt = u.CreatedAt
            }).ToList();
        }

    }
}
