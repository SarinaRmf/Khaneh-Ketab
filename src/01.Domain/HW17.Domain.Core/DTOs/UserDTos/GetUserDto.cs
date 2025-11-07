using Microsoft.AspNetCore.Http;

namespace HW17.Domain.Core.DTOs.UserDTos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public string? ProfilePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
