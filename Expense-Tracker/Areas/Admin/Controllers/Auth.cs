using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Areas.Admin.Controllers {
    [Area("Admin")]
    public class Auth : Controller {
        public IActionResult Login() {
            return View();
        }
    }
}
