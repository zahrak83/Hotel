using Hotel.Dtos;
using Hotel.Enum;
using Hotel.Interface.IServices;
using Hotel.Services;

class Program
{
    static UserService userService = new UserService();
    static HotelRoomService hotelRoomService = new HotelRoomService();
    static RoomDetailService roomDetailService = new RoomDetailService();
    static ReservationService reservationService = new ReservationService();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to Hotel Management System ===");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    return;
                default:
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Register()
    {
        Console.Clear();
        Console.WriteLine("=== Register ===");
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Console.WriteLine("Role (1.Admin  2.Receptionist  3.NormalUser): ");
        if (!int.TryParse(Console.ReadLine(), out int roleInput) || roleInput < 1 || roleInput > 3)
        {
            Console.ReadKey();
            return;
        }

        try
        {
            var dto = new UserRegisterDto
            {
                Username = username,
                Password = password,
                Role = (RoleEnum)roleInput
            };
            var user = userService.Register(dto);
            Console.WriteLine($"User {user.Username} registered successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void Login()
    {
        Console.Clear();
        Console.WriteLine("=== Login ===");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        try
        {
            var user = userService.Login(new UserLoginDto { Username = username, Password = password });
            Console.WriteLine($"Welcome {user.Username}");
            Console.ReadKey();

            switch (user.Role)
            {
                case "Admin":
                    AdminMenu();
                    break;
                case "Receptionist":
                    ReceptionistMenu();
                    break;
                case "NormalUser":
                    NormalUserMenu(user.Id);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void AdminMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Admin Menu ===");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. Update Room Info");
            Console.WriteLine("3. View All Reservations");
            Console.WriteLine("4. Logout");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRoom();
                    break;
                case "2":
                    UpdateRoomInfo();
                    break;
                case "3":
                    ViewAllReservations();
                    break;
                case "4":
                    return;
                default:
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ReceptionistMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Receptionist Menu ===");
            Console.WriteLine("1. Create Reservation");
            Console.WriteLine("2. Logout");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateReservation();
                    break;
                case "2":
                    return;
                default:
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void NormalUserMenu(int userId)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== User Menu ===");
            Console.WriteLine("1. View My Reservations");
            Console.WriteLine("2. Cancel Reservation");
            Console.WriteLine("3. Logout");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewUserReservations(userId);
                    break;
                case "2":
                    CancelReservation(userId);
                    break;
                case "3":
                    return;
                default:
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void AddRoom()
    {
        Console.Clear();
        Console.WriteLine("=== Add Room ===");

        Console.Write("Room Number: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        Console.Write("Price per Night: ");
        int price = int.Parse(Console.ReadLine());

        Console.Write("Has WiFi (y/n): ");
        bool hasWifi = Console.ReadLine().Trim().ToLower() == "y";

        Console.Write("Has Air Conditioner (y/n): ");
        bool hasAir = Console.ReadLine().Trim().ToLower() == "y";

        Console.Write("Description: ");
        string desc = Console.ReadLine();


        try
        {
            var roomDto = new HotelRoomCreateDto
            {
                RoomNumber = roomNumber,
                Capacity = capacity,
                PricePerNight = price
            };

            var detailDto = new RoomDetailCreateDto
            {
                HasWifi = hasWifi,
                HasAirConditioner = hasAir,
                Description = desc
            };

            var created = hotelRoomService.AddRoom(roomDto, detailDto);
            Console.WriteLine($"Room {created.RoomNumber} added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void UpdateRoomInfo()
    {
        Console.Clear();
        Console.WriteLine("=== Update Room Info ===");

        Console.Write("Enter Room Number: ");
        int roomNumber = int.Parse(Console.ReadLine());

        var room = hotelRoomService.GetRoomByNumber(roomNumber);
        if (room == null)
        {
            Console.WriteLine("Room not found!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("1. Update Price");
        Console.WriteLine("2. Update WiFi");
        Console.WriteLine("3. Update Air Conditioner");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("New Price: ");
                int price = int.Parse(Console.ReadLine());
                hotelRoomService.UpdatePrice(room.Id, price);
                Console.WriteLine("Price updated successfully!");
                break;
            case "2":
                Console.Write("Has WiFi? (true/false): ");
                bool wifi = bool.Parse(Console.ReadLine());
                roomDetailService.UpdateHasWifi(room.Id, wifi);
                Console.WriteLine("WiFi updated successfully!");
                break;
            case "3":
                Console.Write("Has Air Conditioner? (true/false): ");
                bool ac = bool.Parse(Console.ReadLine());
                roomDetailService.UpdateHasAirConditioner(room.Id, ac);
                Console.WriteLine("Air Conditioner updated successfully!");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
        Console.ReadKey();
    }

    static void ViewAllReservations()
    {
        Console.Clear();
        Console.WriteLine("=== All Reservations ===");
        var reservations = reservationService.GetAllReservations();

        foreach (var r in reservations)
        {
            Console.WriteLine($"Id:{r.Id}, User:{r.UserId}, Room:{r.RoomId}, Status:{r.Status}, {r.CheckInDate:d} - {r.CheckOutDate:d}");
        }
        Console.ReadKey();
    }

    static void CreateReservation()
    {
        Console.Clear();
        Console.WriteLine("=== Create Reservation ===");

        Console.Write("User Id: ");
        int userId = int.Parse(Console.ReadLine());

        Console.Write("Room Id: ");
        int roomId = int.Parse(Console.ReadLine());

        Console.Write("Check-in Date (yyyy-MM-dd): ");
        DateTime checkIn = DateTime.Parse(Console.ReadLine());

        Console.Write("Check-out Date (yyyy-MM-dd): ");
        DateTime checkOut = DateTime.Parse(Console.ReadLine());

        try
        {
            var dto = new ReservationCreateDto
            {
                UserId = userId,
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut
            };
            var reservation = reservationService.CreateReservation(dto);
            Console.WriteLine($"Reservation {reservation.Id} created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void ViewUserReservations(int userId)
    {
        Console.Clear();
        Console.WriteLine("=== My Reservations ===");

        var reservations = reservationService.GetReservationsByUser(userId);
        if (reservations.Count == 0)
            Console.WriteLine("No reservations found.");

        foreach (var r in reservations)
        {
            Console.WriteLine($"Id:{r.Id}, Room:{r.RoomId}, Status:{r.Status}, {r.CheckInDate:d} - {r.CheckOutDate:d}");
        }
        Console.ReadKey();
    }

    static void CancelReservation(int userId)
    {
        Console.Clear();
        Console.WriteLine("=== Cancel Reservation ===");

        Console.Write("Enter Reservation Id to cancel: ");
        int resId = int.Parse(Console.ReadLine());

        try
        {
            var reservations = reservationService.GetReservationsByUser(userId);
            var reservation = reservations.Find(r => r.Id == resId);

            if (reservation == null)
            {
                Console.WriteLine("Reservation not found!");
                Console.ReadKey();
                return;
            }

            reservationService.CancelReservation(resId);
            Console.WriteLine("Reservation canceled successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadKey();
    }
}