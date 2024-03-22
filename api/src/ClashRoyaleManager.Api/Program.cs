using ClashRoyaleManage.Api.Auth;
using ClashRoyaleManage.Infraestructure;

using FastEndpoints;
using ClashRoyaleManage.Api.Middlewares;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

/// DependencyInjection ///
{
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .ConfigureAutheticationServices(builder.Configuration)
        .AddFastEndpoints()
        .SwaggerDocument();
}

var app = builder.Build();
{

    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseCors("MyPolicy");

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseStatusCodePages();

    app.UseFastEndpoints(c =>
    {
        c.Endpoints.RoutePrefix = "api";
    });

    if (app.Environment.IsDevelopment()) app.UseSwaggerGen();

    app.Run();
}
