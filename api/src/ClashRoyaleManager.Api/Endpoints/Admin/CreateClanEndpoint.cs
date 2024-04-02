using ClashRoyaleManager.Application.Commands.Admin.CreateClan;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateClanEndpoint : Endpoint<CreateClanCommand, CreateClanCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createclan");
    }

    public override async Task HandleAsync(CreateClanCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}