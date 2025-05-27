using FinancialManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.WebApp.Configuration
{
    public static class MvcConfiguration
    {
        public static WebApplicationBuilder AddMvcConfiguration(this WebApplicationBuilder builder)
        {
            // Configure the application to use JSON files for configuration
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services.AddControllersWithViews();

            // Register the DbContext with the SQL Server provider
            builder.Services.AddDbContext<AppDbContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }
    }
}
