using HW17.Domain.Contracts.Repositories;
using HW17.Domain.DTOs;
using HW17.Domain.Entities;
using HW17.Domain.ValueObjects;
using HW17.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Infrastructure.EfCore.Repositories
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public UserLoginDto? Login(string username, string password)
        {
            return _context.Users.Where(u => u.Username == username && u.PasswordHash == password)
                .Select(u => new UserLoginDto
                {
                    IsAdmin = u.IsAdmin,
                    userId = u.Id,
                    userName = u.Username,
                }).FirstOrDefault();

        }

        public bool Register(CreateUserDto userDto)
        {
            var entity = new User
            {
                Username = userDto.Username,
                PasswordHash = userDto.Password,
                Email = userDto.Email,
                CreatedAt = DateTime.Now,
                IsAdmin = userDto.IsAdmin,
                ProfilePath = userDto.ProfilePath,
                Phone = Mobile.Create(userDto.Phone),
            };
            _context.Users.Add(entity);
            return _context.SaveChanges() > 0;
            
        }
        public bool UsernameExist(string username) {

            return _context.Users.Any(u => u.Username == username);

        }
        public GetUserDto? GetUserDetails(int userId)
        {
            return _context.Users.Where(u => u.Id == userId)
                .AsNoTracking()
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Phone = u.Phone.Value,
                    Email = u.Email,
                    Username = u.Username,
                    IsAdmin = u.IsAdmin,
                    ProfilePath= u.ProfilePath,
                    
                })
                .FirstOrDefault();
        }

        public List<GetUserDto> GetUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Phone = u.Phone.Value,
                    Email = u.Email,
                    Username = u.Username,
                    IsAdmin = u.IsAdmin,
                    ProfilePath = u.ProfilePath,

                })
                .ToList();
        }
        public void Delete(int userId) {

            _context.Users.Where(u => u.Id == userId).ExecuteDelete();
        }

        public bool Update(int userId, GetUserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user is not null) { 
            
                user.Email = userDto.Email;
                user.Username = userDto.Username;
                user.IsAdmin = userDto.IsAdmin;
                user.ProfilePath = string.IsNullOrEmpty(userDto.ProfilePath) ? user.ProfilePath : userDto.ProfilePath;
                user.PasswordHash = string.IsNullOrEmpty(userDto.Password) ? user.PasswordHash : userDto.Password ;
                user.Phone.Value = userDto.Phone;
                user.UptatedAt = DateTime.Now;

                _context.SaveChanges();
                return true;
            }
            return false;
            
        }

        public string GetImageProfileUrl(int userId)
        {
            var imgAddress = _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.ProfilePath)
                .FirstOrDefault();


            return imgAddress;
        }
    }
}
