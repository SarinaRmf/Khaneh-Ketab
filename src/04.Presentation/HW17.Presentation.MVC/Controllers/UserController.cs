using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW17.Presentation.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _userServices = new UserServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin() { 
            return View();
        }
        public IActionResult GetUsers()
        {
            var model = _userServices.GetUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteUser(int userId) {
            _userServices.Delete(userId);
            return RedirectToAction("GetUsers");
        }

        public IActionResult AddUser()
        { 
            return View(new CreateUserDto());
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDto model)
        {
            var result = _userServices.Register(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("GetUsers");
            }
            else
            {
                ViewBag.RegisterError = result.Message;
            }
            return View();
        }
        public IActionResult EditUser()
        {
            return View();
        }
    }
}
