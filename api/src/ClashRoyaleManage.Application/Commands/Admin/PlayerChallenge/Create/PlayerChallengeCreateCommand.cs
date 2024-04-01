using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Create;

public class PlayerChallengeCreateCommand : ICommand<Domain.Entities.PlayerChallenge>
{
    public Guid IdPlayer { get; set; }
    public Guid IdChallenge { get; set; }
}