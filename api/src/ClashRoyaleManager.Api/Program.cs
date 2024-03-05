using ClashRoyaleManage.Api.Auth;
using ClashRoyaleManage.Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using FastEndpoints;
using ClashRoyaleManager.Application.Query.Clans;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

/// DependencyInjection ///
{
    builder.Services        
        .AddInfrastructure(builder.Configuration)
        .ConfigureAutheticationServices(builder.Configuration);
}

var app = builder.Build();
{

    app.UseFastEndpoints();

    app.UseHttpsRedirection();
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseStatusCodePages();

    app.Run();
}
