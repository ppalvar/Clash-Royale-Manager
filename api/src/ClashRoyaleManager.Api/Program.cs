using ClashRoyaleManage.Infraestructure;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

/// DependencyInjection ///
{
    builder.Services
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

app.UseFastEndpoints();

app.Run();
