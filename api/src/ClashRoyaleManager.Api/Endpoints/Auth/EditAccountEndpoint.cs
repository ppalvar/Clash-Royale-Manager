using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class EditAccountEndpoint : Endpoint<EditAccountCommand, EditAccountCommandResponse>
{
    private readonly ICommandHandler<EditAccountCommand, EditAccountCommandResponse> _EditAccountCommandHandler;
    public EditAccountEndpoint(ICommandHandler<EditAccountCommand, EditAccountCommandResponse> EditAccountCommandHandler)
    {
        _EditAccountCommandHandler = EditAccountCommandHandler;
    }
    
    public override void Configure()
    {
        Put("/auth/update-account/{userId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(EditAccountCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        var response = await _EditAccountCommandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}