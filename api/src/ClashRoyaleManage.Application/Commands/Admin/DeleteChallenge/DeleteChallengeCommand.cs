using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;

public class DeleteChallengeCommand : ICommand<DeleteChallengeCommandResponse>
{
    public Guid Id { get; set; }
}