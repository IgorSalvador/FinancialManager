using FinancialManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinancialManager.WebApp.Models
{
    public class CookiesAccess
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; }
        public bool IsLoginExpired { get; set; }

        public CookiesAccess(AppDbContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public void Initialize()
        {
            try
            {
                var user = _httpContextAccessor.HttpContext?.User;

                if (user == null || !user!.Identity!.IsAuthenticated)
                    throw new Exception("User is not authenticated.");

                var identity = (ClaimsIdentity)user.Identity;
                var claims = identity.Claims.ToList();

                this.UserId = Guid.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
                this.Username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? string.Empty;
                this.Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
                this.Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
                this.IsLoggedIn = true;
                this.IsLoginExpired = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                this.UserId = Guid.Empty;
                this.Username = string.Empty;
                this.Email = string.Empty;
                this.Role = string.Empty;
                this.IsLoggedIn = false;
                this.IsLoginExpired = true;

            }
            finally
            {
                _context.Database.GetDbConnection().Close();
            }
        }
    }

    public static class CurrentCookies
    {
        public static Guid UserId { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static bool IsLoggedIn { get; set; }

        public static void GetCookies(CookiesAccess cookiesAccess)
        {
            cookiesAccess.Initialize();

            UserId = cookiesAccess.UserId;
            Username = cookiesAccess.Username;
            Email = cookiesAccess.Email;
            Role = cookiesAccess.Role;
            IsLoggedIn = cookiesAccess.IsLoggedIn;
        }
    }
}
