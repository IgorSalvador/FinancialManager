using FinancialManager.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.WebApp.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            if(IsAuthenticated())
                return RedirectToAction("Index", "Home");

            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
