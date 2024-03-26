using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ListChallengeQuery : ICommand<ListChallengeQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}