using HW17.Domain.Core.DTOs.BookDtos;
using HW17.Domain.Core.DTOs.CategoryDtos;

namespace HW17.Presentation.MVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<GetBookDtos> Books { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
    }
}
