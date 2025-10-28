using HW17.Domain.DTOs;
using HW17.Domain.Entities;

namespace HW17.Presentation.MVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<GetBookDtos> Books { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
    }
}
