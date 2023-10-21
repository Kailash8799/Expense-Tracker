using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Areas.Admin.Controllers {

    [Area("Admin")]
    public class AuthController : Controller {
        public IActionResult Login() {
            return View();
        }
    }
}
