using Expense.DataAccess.Repository;
using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (User.Identity.Name != null) {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                        var identity = new ClaimsIdentity(new[] {
                          new Claim(ClaimTypes.Name, user.Id.ToString()),
                          new Claim(ClaimTypes.Email, user.Email),
                            }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
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

        public IActionResult Logout() {
            if (User.Identity.Name == null) {
                return RedirectToAction("Index", "Auth");
            }
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Auth");
        }

        public IActionResult Signup()
        {
            if (User.Identity.Name != null) {
                return RedirectToAction("Index", "Home");
            }
            return View("Signup");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
