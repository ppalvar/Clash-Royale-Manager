using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteAccountEndpoint : Endpoint<DeleteAccountCommand, DeleteAccountCommandResponse>
{
    private readonly ICommandHandler<DeleteAccountCommand, DeleteAccountCommandResponse> _DeleteAccountCommandHandler;
    public DeleteAccountEndpoint(ICommandHandler<DeleteAccountCommand, DeleteAccountCommandResponse> DeleteAccountCommandHandler)
    {
        _DeleteAccountCommandHandler = DeleteAccountCommandHandler;
    }
    
    public override void Configure()
    {
        Get("/auth/delete-account/{userId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(DeleteAccountCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId"); 
        var response = await _DeleteAccountCommandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}