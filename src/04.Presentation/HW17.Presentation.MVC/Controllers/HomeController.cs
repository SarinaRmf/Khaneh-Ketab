using HW17.Domain.Contracts.Services;
using HW17.Presentation.MVC.Models;
using HW17.Presentation.MVC.Models.ViewModels;
using HW17.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW17.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly ICategoryServices _categoryServices;

        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            IBookServices bookServices,
            ICategoryServices categoryServices)
            {
                _logger = logger;
                _bookServices = bookServices;
                _categoryServices = categoryServices;
            }



        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Books = _bookServices.GetNewestBooks(),
                Categories = _categoryServices.GetCategories()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
