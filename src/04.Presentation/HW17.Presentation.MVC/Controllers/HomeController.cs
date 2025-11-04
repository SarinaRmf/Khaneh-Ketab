using HW17.Domain.Contracts.Services;
using HW17.Presentation.MVC.Models;
using HW17.Presentation.MVC.Models.ViewModels;
using HW17.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW17.Presentation.MVC.Controllers
{
    public class HomeController(IBookServices _bookServices, ICategoryServices _categoryServices, ILogger<HomeController> _logger) : Controller
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
