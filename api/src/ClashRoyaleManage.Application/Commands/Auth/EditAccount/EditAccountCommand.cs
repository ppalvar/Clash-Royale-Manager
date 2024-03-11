using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class EditAccountCommand : ICommand<EditAccountCommandResponse>
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}