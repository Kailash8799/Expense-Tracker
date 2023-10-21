using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Expense_Tracker.Areas.Admin.Controllers {

    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index() {
            List<Category> categories = _categoryRepository.GetAllCategories().ToList();
            return View(categories);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) {
            
            if(ModelState.IsValid && category != null) {
                if(category.Title != null && category.Type != null) {
                    _categoryRepository.CreateCategory(category);
                    return RedirectToAction("Index","Category");
                } else {
                TempData["message"] = "All fields required";
                    TempData["type"] = "danger";

                }
            } else {
                TempData["message"] = "All fields required";
                TempData["type"] = "danger";
            }
            return View();
        }

        
        public IActionResult Edit(int? id) {
            if(id == null || id == 0) {
                TempData["message"] = "Invalid category";
                TempData["type"] = "danger";
                return View("Index","Category");
            } else {
                Category? category = _categoryRepository.GetCategoryById(id);
                if(category != null) {
                    return View(category);
                } else {
                    TempData["message"] = "Invalid category";
                    TempData["type"] = "danger";
                    return View("Index", "Category");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category) {
                if (category == null || category.Title.IsNullOrEmpty() || category.Type.IsNullOrEmpty() ) {
                TempData["message"] = "Some error occured!";
                TempData["type"] = "danger";
                return RedirectToAction("Index", "Category");
            } else {
                _categoryRepository.UpdateCategory(category!);
                    TempData["message"] = "Updated successfully";
                    TempData["type"] = "success";
                    return RedirectToAction("Index", "Category");
                }      
        }

        public IActionResult Delete(int? id) {
            if (id == null || id == 0) {
                TempData["message"] = "Invalid category";
                TempData["type"] = "danger";
                return RedirectToAction("index", "category");
            } else {
                Category? category = _categoryRepository.GetCategoryById(id);
                if (category != null) {
                    _categoryRepository.DeleteCategory(category);
                    TempData["message"] = "Deleted successfully";
                    TempData["type"] = "success";
                    return RedirectToAction("index", "category");
                } else {
                    TempData["message"] = "Some error occurred!";
                    TempData["type"] = "danger";
                    return RedirectToAction("index", "category");
                }
            }
        }
       
    }
}
