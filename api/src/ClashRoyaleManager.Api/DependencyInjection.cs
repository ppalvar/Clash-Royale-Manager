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

namespace ClashRoyaleManage.Api.Auth;


public static partial class DependencyInjection
{
    public static IServiceCollection ConfigureAutheticationServices(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secret = jwtSettings.GetValue<string>("Secret");
        var issuer = jwtSettings.GetValue<string>("Issuer");
        var audience = jwtSettings.GetValue<string>("Audience");

        var key = Encoding.UTF8.GetBytes(secret);

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
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
        });

        services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5198")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                    });
            });

        // ENDPOINTS
        services
            .AddScoped<ICommandHandler<RegisterCommand, RegisterCommandResponse>, RegisterCommandHandler>()
            .AddScoped<ICommandHandler<LoginCommand, LoginCommandResponse>, LoginCommandHandler>()
            .AddScoped<ICommandHandler<ListClanQuery, ListClanQueryResponse>, ListClanQueryHandler>();

        return services;
    }

}