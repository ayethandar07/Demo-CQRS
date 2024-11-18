using CleanArchitecture.Domain.Repositoty;
using CleanArchitecture.Infra.Data;
using CleanArchitecture.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("BlogDbContext") ??
            throw new InvalidOperationException("connection string 'BlogDbContext' not found.")
            ));

        services.AddTransient<IBlogRepository, BlogRepository>();
        return services;
    }
}
