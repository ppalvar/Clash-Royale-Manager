using ClashRoyaleManager.Application.Commands.Admin.CreateCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateCardEndpoint : Endpoint<CreateCardCommand>
{
    public override void Configure()
    {
        Post("/admin/createcard");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCardCommand req, CancellationToken ct)
    {
        await req.ExecuteAsync(ct);
        await SendOkAsync();
    }
}