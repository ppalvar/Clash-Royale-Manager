using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerChallenge.GetAll;

public record GetAllPlayerChallengesQuery(int Page = 1, int PageSize = 10) : ICommand<GetAllPlayerChallengesQueryResponse>;