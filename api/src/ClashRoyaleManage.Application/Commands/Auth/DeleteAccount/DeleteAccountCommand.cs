using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommand : ICommand<RegisterCommandResponse>
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}