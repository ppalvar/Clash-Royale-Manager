using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerChallenge.GetAll;

public class GetAllPlayerChallengesQueryHandler(IPlayerChallengeRepository _playerChallengeRepository) : CommandHandler<GetAllPlayerChallengesQuery, GetAllPlayerChallengesQueryResponse>
{
    public override async Task<GetAllPlayerChallengesQueryResponse> ExecuteAsync(GetAllPlayerChallengesQuery command, CancellationToken ct = default)
    {
        var response = await _playerChallengeRepository.GetPagination(command.Page, command.PageSize);
        return new GetAllPlayerChallengesQueryResponse
        {
            Page = command.Page,
            TotalPages = response.totalPages,
            PlayerChallenges = response.playerChallenges
        };
    }
}