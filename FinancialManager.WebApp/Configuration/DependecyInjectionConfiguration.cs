using FinancialManager.WebApp.Models;

namespace FinancialManager.WebApp.Configuration
{
    public static class DependecyInjectionConfiguration
    {
        public static WebApplicationBuilder AddDepencencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<CookiesAccess>();

            return builder;
        }
    }
}
