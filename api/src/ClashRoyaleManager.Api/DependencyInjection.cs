using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FastEndpoints;
using ClashRoyaleManager.Application.Query.Clans;
using ClashRoyaleManager.Application.Commands.Auth;
using ClashRoyaleManager.Application.Query.Auth;
using ClashRoyaleManager.Application.Query.Cards;
using ClashRoyaleManager.Application.Query.Wars;
using ClashRoyaleManager.Application.Query.Battles;
using ClashRoyaleManager.Application.Commands.Admin.CreateCard;
using ClashRoyaleManager.Application.Commands.Admin.UpdateCard;
using ClashRoyaleManager.Application.Commands.Admin.DeleteCard;
using ClashRoyaleManager.Application.Commands.Admin.CreatePlayer;
using ClashRoyaleManager.Application.Query.Players;
using ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;
using ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;
using ClashRoyaleManager.Application.Commands.Admin.CreateWar;
using ClashRoyaleManager.Application.Commands.Admin.DeleteWar;
using ClashRoyaleManager.Application.Commands.Admin.UpdateWar;
using ClashRoyaleManager.Application.Commands.Admin.CreateChallenge;
using ClashRoyaleManager.Application.Query.Challenges;
using ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;
using ClashRoyaleManager.Application.Commands.Admin.UpdateChallenge;
using ClashRoyaleManager.Application.Commands.Admin.CreateBattle;
using ClashRoyaleManager.Application.Commands.Admin.CreateClan;
using ClashRoyaleManager.Application.Commands.Admin.DeleteClan;
using ClashRoyaleManager.Application.Commands.Admin.UpdateClan;
using ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;
using ClashRoyaleManager.Application.Query.SpellCards;
using ClashRoyaleManager.Application.Commands.Admin.DeleteSpellCard;
using ClashRoyaleManager.Application.Commands.Admin.UpdateSpellCard;
using ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;
using ClashRoyaleManager.Application.Query.StructureCards;
using ClashRoyaleManager.Application.Commands.Admin.DeleteStructureCard;
using ClashRoyaleManager.Application.Commands.Admin.UpdateStructureCard;
using ClashRoyaleManager.Application.Commands.Admin.CreateTroopCard;
using ClashRoyaleManager.Application.Query.TroopCards;
using ClashRoyaleManager.Application.Commands.Admin.DeleteTroopCard;
using ClashRoyaleManager.Application.Commands.Admin.UpdateTroopCard;

namespace ClashRoyaleManage.Api.Auth;


public static partial class DependencyInjection
{
    public static IServiceCollection ConfigureAutheticationServices(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                    });
            });

        var jwtSettings = configuration.GetSection("JwtSettings");
        var secret = jwtSettings.GetValue<string>("Secret");
        var issuer = jwtSettings.GetValue<string>("Issuer");
        var audience = jwtSettings.GetValue<string>("Audience");

        var key = Encoding.UTF8.GetBytes(secret);

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
        });

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience
                };
            });

        return services;
    }
}