using ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateSpellCardEndpoint : Endpoint<CreateSpellCardCommand, CreateSpellCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createspellcard");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSpellCardCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}