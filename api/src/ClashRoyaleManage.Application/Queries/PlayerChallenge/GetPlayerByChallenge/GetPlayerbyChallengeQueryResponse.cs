using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Queries.PlayerChallenge.GetByChallenge;

public class GetPlayerByChallengeQueryResponse
{
    public IQueryable<Player> Players { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}