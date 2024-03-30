using ClashRoyaleManage.Infrastructure.Services;
using ClashRoyaleManage.Infrastructure.Services.Auth;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
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
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddDbContext<DefaultDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres"),
                x => x.MigrationsAssembly("ClashRoyaleManager.Api")
            )
        );

        Task.Run(
            () => InitializeDatabase(services.BuildServiceProvider().GetRequiredService<DefaultDbContext>())
        );

        services.AddScoped<IJwtTokenGenerator, JwTokenGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IEncryptService, EncryptService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBattleRepository, BattleRepository>()
                .AddScoped<ICardRepository, CardRepository>()
                .AddScoped<IClanRepository, ClanRepository>()
                .AddScoped<ITypeClanRepository, TypeClanRepository>()
                .AddScoped<IWarRepository, WarRepository>()
                .AddScoped<IChallengeRepository, ChallengeRepository>()
                .AddScoped<IPlayerRepository, PlayerRepository>();

        services.AddScoped<IGetCurrentUserLoginService, GetCurrentUserLoginService>();

        return services;
    }

    public static async Task InitializeDatabase(DefaultDbContext context)
    {
        Guid InvitationId = new("1e2b59b1-3be6-40cf-a7de-660de6478331");
        Guid OpenId = new("bd818cb4-26b0-402b-a6e8-ea8c63eb0416");

        TypeClanRepository typeClanRepository = new TypeClanRepository(context);
        
        if (await typeClanRepository.Get(InvitationId) is not TypeClan typeClanInvitation)
        {
            typeClanInvitation = new TypeClan{
                Id = InvitationId,
                Name = TipoEnum.Invitacion
            };

            await typeClanRepository.Create(typeClanInvitation);
        }
        
        if (await typeClanRepository.Get(OpenId) is not TypeClan typeClanOpen)
        {
            typeClanOpen = new TypeClan{
                Id = OpenId,
                Name = TipoEnum.Abierto
            };

            await typeClanRepository.Create(typeClanOpen);
        }
    }
}