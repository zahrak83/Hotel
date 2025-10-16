using Hotel.Enum;

namespace Hotel.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public RoleEnum Role { get; set; }
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
    }
}
