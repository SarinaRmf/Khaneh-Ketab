using HW17.Domain.Core.Contracts.Services;
using HW17.Domain.Core.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace HW17.Presentation.MVC.Controllers
{
    public class CategoryController(ICategoryService _categoryServices, ILogger<CategoryController> _logger) : Controller
    {
        public IActionResult Index()
        {
            var model = _categoryServices.GetCategories();
            return View(model);
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryServices.Delete(categoryId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View(new CreateCategoryDto());
        }
        [HttpPost]
        public IActionResult Add(CreateCategoryDto model)
        {

            var result = _categoryServices.Add(model);
            if (result.IsSuccess)
            {

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AddError = result.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int categoryId)
        {

            var model = _categoryServices.GetCategoryById(categoryId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategory(GetCategoryDto model)
        {
            var result = _categoryServices.Update(model.Id, model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
