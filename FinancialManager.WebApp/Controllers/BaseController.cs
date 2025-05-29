using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Determines whether the current user is authenticated.
        /// </summary>
        /// <remarks>This method checks the authentication status of the user associated with the current
        /// HTTP context. If the HTTP context or user identity is unavailable, the method returns <see
        /// langword="false"/>.</remarks>
        /// <returns><see langword="true"/> if the current user is authenticated; otherwise, <see langword="false"/>.</returns>
        protected bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
