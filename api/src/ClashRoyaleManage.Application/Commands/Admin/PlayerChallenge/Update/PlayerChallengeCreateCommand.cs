using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Update;

public class PlayerChallengeUpdateCommand : ICommand<Domain.Entities.PlayerChallenge>
{
    public Guid IdPlayer { get; set; }
    public Guid IdChallenge { get; set; }
}