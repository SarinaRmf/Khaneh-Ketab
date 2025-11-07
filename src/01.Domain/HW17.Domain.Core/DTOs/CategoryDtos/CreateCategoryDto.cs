using Microsoft.AspNetCore.Http;

namespace HW17.Domain.Core.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Imgfile { get; set; }
    }
}
