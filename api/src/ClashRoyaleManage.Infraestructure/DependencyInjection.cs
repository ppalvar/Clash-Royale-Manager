using ClashRoyaleManage.Infrastructure.Services;
using ClashRoyaleManage.Infrastructure.Services.Auth;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Infraestructure.DbContexts;
using ClashRoyaleManager.Infraestructure.Repositories;
using ClashRoyaleManager.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleManage.Infraestructure;


public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
{
    public DefaultDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@Directory.GetCurrentDirectory() + "/../ClashRoyaleManager.Api/appsettings.Development.json")
            .Build();
        var builder = new DbContextOptionsBuilder<DefaultDbContext>();
        var connectionString = configuration.GetConnectionString("Postgres");
        builder.UseNpgsql(connectionString);
        return new DefaultDbContext(builder.Options);
    }
}


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddDbContext<DefaultDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres"),
                x => x.MigrationsAssembly("ClashRoyaleManager.Api")
            )
        );

        services.AddSingleton<IJwtTokenGenerator, JwTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IEncryptService, EncryptService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBattleRepository, BattleRepository>()
                .AddScoped<ICardRepository, CardRepository>()
                .AddScoped<IClanRepository, ClanRepository>()
                .AddScoped<IWarRepository, WarRepository>()
                .AddScoped<IPlayerRepository, PlayerRepository>();
        

        services.AddScoped<IGetCurrentUserLoginService, GetCurrentUserLoginService>();

        Task.Run(
            () => InitializeDatabase(services.BuildServiceProvider().GetRequiredService<DefaultDbContext>())
        );

        return services;
    }

    public static async Task InitializeDatabase(DefaultDbContext context)
    {
        // Initialize datas
    }
}