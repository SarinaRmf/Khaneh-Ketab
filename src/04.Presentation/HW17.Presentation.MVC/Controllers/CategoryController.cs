using HW17.Domain.Contracts.Services;
using HW17.Domain.DTOs;
using HW17.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW17.Presentation.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryServices = new CategoryServices();
        }
        public IActionResult Index()
        {
            var model = _categoryServices.GetCategories();
            return View(model);
        }
        public IActionResult DeleteCategory(int categoryId) { 
             _categoryServices.Delete(categoryId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add() { 
        
            return View(new CreateCategoryDto());
        }
        [HttpPost]
        public IActionResult Add(CreateCategoryDto model) { 
        
            var result = _categoryServices.Add(model);
            if (result.IsSuccess) {

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AddError = result.Message;
            }
                return View();
        }
    }
}
