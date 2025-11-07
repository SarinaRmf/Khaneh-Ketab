using HW17.Domain.Core.DTOs.UserDTos;

namespace HW17.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        UserLoginDto Login(string username, string password);
        bool Register(CreateUserDto userDto);
        bool UsernameExist(string username);
        GetUserDto? GetUserDetails(int userId);
        List<GetUserDto> GetUsers();
        void Delete(int userId);
        bool Update(int userId, GetUserDto userDto);
        string GetImageProfileUrl(int userId);
    }
}
