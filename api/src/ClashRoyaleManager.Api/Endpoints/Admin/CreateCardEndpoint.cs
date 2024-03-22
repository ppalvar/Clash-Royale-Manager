using ClashRoyaleManager.Application.Commands.Admin.CreateCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateCardEndpoint : Endpoint<CreateCardCommand, CreateCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createcard");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCardCommand req, CancellationToken ct)
    {
        CreateCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}