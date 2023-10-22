using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Expense_Tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ITransactionRepository transactionRepository,ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            if(User.Identity.Name == null) {
                return RedirectToAction("Index","Auth");
            }
            List<Transaction> transactions = _transactionRepository.GetTransactions(Int32.Parse(User.Identity!.Name!)).ToList();
            return View(transactions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateTransacation() {
            if (User.Identity.Name == null) {
                return RedirectToAction("Index", "Auth");
            }
            IEnumerable<SelectListItem> categories = _categoryRepository.GetAllCategories().Select(u=> new SelectListItem {Text= u.Title,Value=u.Id.ToString()});
            ViewBag.CategoriesList = categories;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTransacation(Transaction transaction) {
            if (User.Identity.Name == null) {
                return RedirectToAction("Index", "Auth");
            }
            if (ModelState.IsValid) {
                _transactionRepository.CreateTransition(transaction);
                TempData["message"] = "Transaction created";
                TempData["type"] = "success";
                return RedirectToAction("Index", "Home");

            } else {
                IEnumerable<SelectListItem> categories = _categoryRepository.GetAllCategories().Select(u => new SelectListItem { Text = u.Title, Value = u.Id.ToString() });
                ViewBag.CategoriesList = categories;
                TempData["message"] = "All fields are required ";
                TempData["type"] = "danger";
                return View();
            }
            
        }

        public IActionResult Delete(int id) {
            if (User.Identity.Name == null) {
                return RedirectToAction("Index", "Auth");
            }
            if (id == 0) {
                TempData["message"] = "Error occured!";
                TempData["type"] = "danger";
                return RedirectToAction("Index", "Home");
            } else {
                Transaction? transaction = _transactionRepository.GetTransactionById(id);
                if (transaction != null) {
                    _transactionRepository.DeleteTransition(transaction);
                    TempData["message"] = "Deleted!";
                    TempData["type"] = "success";
                    return RedirectToAction("Index", "Home");
                } else {
                    TempData["message"] = "Error occured!";
                    TempData["type"] = "danger";
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public IActionResult Edit(int id) {
            if (User.Identity.Name == null) {
                return RedirectToAction("Index", "Auth");
            }
            if (id == 0) {
                TempData["message"] = "Error occured!";
                TempData["type"] = "danger";
                return RedirectToAction("Index", "Home");
            } else {
                Transaction? transaction = _transactionRepository.GetTransactionById(id);
                if (transaction != null) {
                    IEnumerable<SelectListItem> categories = _categoryRepository.GetAllCategories().Select(u => new SelectListItem { Text = u.Title, Value = u.Id.ToString() });
                    ViewBag.CategoriesList = categories;
                    return View(transaction);
                } else {
                    TempData["message"] = "Error occured!";
                    TempData["type"] = "danger";
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Transaction transaction) {
            if (User.Identity.Name == null) {
                return RedirectToAction("Index", "Auth");
            }
            if (ModelState.IsValid) {
                _transactionRepository.UpdateTransition(transaction);
                TempData["message"] = "Transaction edited";
                TempData["type"] = "success";
                return RedirectToAction("Index", "Home");

            } else {
                IEnumerable<SelectListItem> categories = _categoryRepository.GetAllCategories().Select(u => new SelectListItem { Text = u.Title, Value = u.Id.ToString() });
                ViewBag.CategoriesList = categories;
                TempData["message"] = "All fields are required ";
                TempData["type"] = "danger";
                return View(transaction);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}