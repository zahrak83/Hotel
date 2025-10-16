using Hotel.Dtos;

namespace Hotel.Interface.IServices
{
    public interface IUserService
    {
        GetUserDto Register(UserRegisterDto dto);
        GetUserDto Login(UserLoginDto dto);
        List<GetUserDto> GetAll();

    }
}

