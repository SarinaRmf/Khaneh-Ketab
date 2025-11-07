using HW17.Domain.Core.DTOs;
using HW17.Domain.Core.DTOs.UserDTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Core.Contracts.Services
{
    public interface IUserService
    {
        ResultDto<UserLoginDto> Login(string username, string password);
        ResultDto<bool> Register(CreateUserDto userDto);
        List<GetUserDto> GetUsers();
        void Delete(int userId);
        GetUserDto? GetUserDetails(int userId);
        bool Update(int userId, GetUserDto userDto);
    }
}
