using HW17.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Contracts.Services
{
    public interface IUserServices
    {
        ResultDto<UserLoginDto> Login(string username, string password);
        ResultDto<bool> Register(CreateUserDto userDto);
        List<GetUserDto> GetUsers();
        void Delete(int userId);
    }
}
