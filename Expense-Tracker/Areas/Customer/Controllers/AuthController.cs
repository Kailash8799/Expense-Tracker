using Expense.DataAccess.Repository;
using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AuthController : Controller
    {

        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            if (email == null)
            {
                ModelState.AddModelError("email", "Email is not valid");
            }
            if (password != null && password.Length < 5)
            {
                ModelState.AddModelError("password", "Password must be minimum 5 character");
            }
            if (ModelState.IsValid && email != null)
            {
                User? user = _userRepository.GetUserByEmail(email);
                if(user != null) {
                    if(user.Password == password) {
                        return RedirectToAction("Index", "Home");
                    } else {
                        TempData["message"] = "Invalid credentials";
                        TempData["type"] = "danger";
                        return View();
                    }
                } else {
                    TempData["message"] = "User not exits";
                    TempData["type"] = "danger";
                    return View();
                }
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View("Signup");
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.GetUserByEmail(user.Email) == null)
                {
                    _userRepository.CreateUser(user);
                    return RedirectToAction("Index","Auth");
                }
                else
                {
                    TempData["message"] = "User already exits with this email";
                    TempData["type"] = "danger";
                }
            }
            return View();
        }
    }
}
