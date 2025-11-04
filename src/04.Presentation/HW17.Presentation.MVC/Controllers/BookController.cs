using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW17.Presentation.MVC.Controllers
{
    public class BookController(ILogger<BookController> _logger, ICategoryServices _categoryServices, IBookServices _bookServices) : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _categoryServices.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateBookDto bookDto)
        {
            _bookServices.Add(bookDto);
            return RedirectToAction("GetBooks");
        }

        public IActionResult GetBooks()
        {
            var books = _bookServices.GetBooks();
            return View(books);
        }
        
    }
}
