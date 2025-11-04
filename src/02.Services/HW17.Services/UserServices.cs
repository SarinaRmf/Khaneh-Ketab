using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Domain.Entities;
using HW17.Framework;
using HW17.Infrastructure.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Services
{
    public class UserServices(IUserRepository _repo, IFileService _fileService) : IUserServices
    {
        public List<GetUserDto> GetUsers()
        {
            return _repo.GetUsers();
        }

        public ResultDto<UserLoginDto> Login(string username, string password)
        {

            var result  = _repo.Login(username, password.ToMd5Hex());
            if (result is null)
            {
                return new ResultDto<UserLoginDto> { IsSuccess = false , Message = "نام کاربری یا رمز عبور اشتباه است"};
            }
            return new ResultDto<UserLoginDto> { IsSuccess = true, Message = "لاگین با موفقیت انجام شد" , Data = result};
        }

        public ResultDto<bool> Register(CreateUserDto userDto)
        {
            if (_repo.UsernameExist(userDto.Username)) {

                return new ResultDto<bool> { IsSuccess = false, Message = "نام کاربری موجود می باشد" };
            }

            userDto.Password = userDto.Password.ToMd5Hex();
            userDto.ProfilePath = _fileService.Upload(userDto.ProfileFile, "users");
            if (_repo.Register(userDto))
            {
                return new ResultDto<bool> { IsSuccess = true, Message = "ثبت نام با موفقیت انجام شد" };
            }
            return new ResultDto<bool> { IsSuccess = false, Message = "ثبت نام انجام نشد" };
        }

        public void Delete(int userId)
        {
            _repo.Delete(userId);
        }

        public GetUserDto? GetUserDetails(int userId)
        {
            return _repo.GetUserDetails(userId);
        }

        public bool Update(int userId, GetUserDto userDto)
        {
            if (userDto.ImageFile is not null)
            {
                var currentImageUrl = _repo.GetImageProfileUrl(userId);

                if (!string.IsNullOrEmpty(currentImageUrl))
                {
                    _fileService.Delete(currentImageUrl);
                    userDto.ProfilePath = _fileService.Upload(userDto.ImageFile, "Category");
                }
            }
            if (userDto.Password is not null)
            {
                userDto.Password = userDto.Password.ToMd5Hex();
            }
            var result = _repo.Update(userId, userDto);
            return result;
        }
    }
}
