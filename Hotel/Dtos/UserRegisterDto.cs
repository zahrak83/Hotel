using Hotel.Enum;

namespace Hotel.Dtos
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
