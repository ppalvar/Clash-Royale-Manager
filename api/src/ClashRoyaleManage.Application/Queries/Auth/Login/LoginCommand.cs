using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Auth;

public class LoginCommand : ICommand<LoginCommandResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}