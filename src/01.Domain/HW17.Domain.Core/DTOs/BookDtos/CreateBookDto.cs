using Microsoft.AspNetCore.Http;

namespace HW17.Domain.Core.DTOs.BookDtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Auther { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
