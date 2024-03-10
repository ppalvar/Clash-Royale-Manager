using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class DeleteAccountCommand : ICommand<DeleteAccountCommandResponse>
{
    public Guid Id { get; set; }
}