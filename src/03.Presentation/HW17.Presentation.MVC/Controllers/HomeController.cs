using HW17.Domain.Core.Contracts.Services;
using HW17.Presentation.MVC.Models;
using HW17.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW17.Presentation.MVC.Controllers
{
    public class HomeController(IBookService _bookServices, ICategoryService _categoryServices, ILogger<HomeController> _logger) : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Books = _bookServices.GetNewestBooks(),
                Categories = _categoryServices.GetCategories()
            };

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
