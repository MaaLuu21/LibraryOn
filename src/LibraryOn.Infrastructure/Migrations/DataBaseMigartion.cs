using LibraryOn.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryOn.Infrastructure.Migrations;
public class DataBaseMigartion
{
    public static async Task MigrateDataBse(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<LibraryOnDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
