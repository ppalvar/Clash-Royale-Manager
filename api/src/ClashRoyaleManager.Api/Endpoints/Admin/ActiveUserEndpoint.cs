using ClashRoyaleManager.Application.Commands.Admin.ActiveUser;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ActiveUserEndpoint : Endpoint<ActiveUserCommand>
{
    public override void Configure()
    {
        Get("/admin/active-user/{Id}/{Active}");
    }

    public override async Task HandleAsync(ActiveUserCommand req, CancellationToken ct)
    {
        string action = req.Active ? "activado" : "desactivado";
        await req.ExecuteAsync(ct);
        await SendAsync($"Usuario {action} con éxito.");
    }
}