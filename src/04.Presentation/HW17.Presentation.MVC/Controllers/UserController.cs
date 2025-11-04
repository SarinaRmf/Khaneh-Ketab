using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW17.Presentation.MVC.Controllers
{
    public class UserController(IUserServices _userServices, ILogger<UserController> _logger) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin() { 
            return View();
        }

        [HttpGet]
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



        [HttpGet]
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



        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            var model = _userServices.GetUserDetails(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(GetUserDto model)
        {
            var result = _userServices.Update(model.Id, model);
            if (result)
            {
                return RedirectToAction("GetUsers");
            }
                return View(model);
        }
    }
}
