using HW17.Domain.Core.Contracts.Services;
using HW17.Domain.Core.DTOs.UserDTos;
using HW17.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HW17.Presentation.MVC.Controllers
{
    public class AccountController(ILogger<AccountController> _logger, IUserService userServices) : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new CreateUserDto());
        }

        [HttpPost]
        public IActionResult Register(CreateUserDto model)
        {
            var result = userServices.Register(model);
            if (result.IsSuccess)
            {

                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.RegisterError = result.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var result = userServices.Login(model.Username, model.Password);
            if (result.IsSuccess)
            {
                if (result.Data.IsAdmin == true)
                {
                    return RedirectToAction("Admin", "User");
                }
                else
                {

                }
            }
            else
            {
                ViewBag.LoginError = result.Message;
            }
            return View();
        }
    }
}
