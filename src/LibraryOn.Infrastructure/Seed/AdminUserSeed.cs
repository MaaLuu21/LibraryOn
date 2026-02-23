using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Security.Cryptography;
using LibraryOn.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LibraryOn.Infrastructure.Seed;
public static class AdminUserSeed
{

    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var context = scope.ServiceProvider
            .GetRequiredService<LibraryOnDbContext>();

        var loggerFactory = scope.ServiceProvider
            .GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("AdminUserSeed");

        var passwordEncripter = scope.ServiceProvider
            .GetRequiredService<IPasswordEncripter>();

        if (await context.Employees.AnyAsync(e => e.Role == Roles.ADMIN))
        {
            logger.LogInformation("AdminUserSeed skipped: admin already exists.");
            return;
        }

        var adminEmail = Environment.GetEnvironmentVariable("INITIAL_ADMIN_EMAIL");
        var adminPassword = Environment.GetEnvironmentVariable("INITIAL_ADMIN_PASSWORD");

        if (string.IsNullOrWhiteSpace(adminPassword) || string.IsNullOrWhiteSpace(adminEmail))
        {
            logger.LogWarning(
                "AdminUserSeed skipped: INITIAL_ADMIN_EMAIL or INITIAL_ADMIN_PASSWORD not configured");
            return;
        }

        var admin = new Employee
        {
            Name = "Administrador",
            Email = adminEmail,
            Password = passwordEncripter.Encrypty(adminPassword),
            Role = Roles.ADMIN,
            EmployeeIdentifier = Guid.NewGuid(),
            MustChangePassword = true
           
        };

        context.Employees.Add(admin);
        await context.SaveChangesAsync();

        logger.LogInformation("Initial admin user created successfully");

    }
}
