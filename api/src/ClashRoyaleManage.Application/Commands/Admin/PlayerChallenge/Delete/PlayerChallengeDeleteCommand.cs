using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Delete;

public class PlayerChallengeDeleteCommand : ICommand<Domain.Entities.PlayerChallenge>
{
    public Guid IdPlayer { get; set; }
    public Guid IdChallenge { get; set; }
}