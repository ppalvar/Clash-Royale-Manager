using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ChallengeQuery : ICommand<ChallengeQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}