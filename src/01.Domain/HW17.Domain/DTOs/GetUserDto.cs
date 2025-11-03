
using HW17.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.DTOs
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
