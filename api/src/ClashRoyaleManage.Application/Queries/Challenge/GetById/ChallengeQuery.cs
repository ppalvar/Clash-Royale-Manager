using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ChallengeQuery : ICommand<ChallengeQueryResponse>
{
    public Guid Id { get; set; }
}