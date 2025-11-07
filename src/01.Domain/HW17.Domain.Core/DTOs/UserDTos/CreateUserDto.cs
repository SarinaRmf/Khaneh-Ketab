using Microsoft.AspNetCore.Http;

namespace HW17.Domain.Core.DTOs.UserDTos
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public string? ProfilePath { get; set; }
        public IFormFile? ProfileFile { get; set; }
    }
}
