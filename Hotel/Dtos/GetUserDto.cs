using Hotel.Enum;

namespace Hotel.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
    }
}
