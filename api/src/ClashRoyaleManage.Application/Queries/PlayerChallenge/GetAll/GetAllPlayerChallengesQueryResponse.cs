namespace ClashRoyaleManager.Application.Queries.PlayerChallenge.GetAll;

public class GetAllPlayerChallengesQueryResponse
{
    public IQueryable<Domain.Entities.PlayerChallenge> PlayerChallenges { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}