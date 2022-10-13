using App.Models;
using App.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        return services
            .AddPooledDbContextFactory<LibraryContext>(x => x.UseSqlServer(connectionString));
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IAuthorService, AuthorService>()
            .AddTransient<IBookService, BookService>();
    }
}