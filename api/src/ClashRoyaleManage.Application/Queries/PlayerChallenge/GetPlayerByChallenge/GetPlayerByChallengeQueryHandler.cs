using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerChallenge.GetByChallenge;

public class GetPlayerByChallengeQueryHandler(IPlayerChallengeRepository _playerChallengeRepository) : CommandHandler<GetPlayerByChallengeQuery, GetPlayerByChallengeQueryResponse>
{
    public override async Task<GetPlayerByChallengeQueryResponse> ExecuteAsync(GetPlayerByChallengeQuery command, CancellationToken ct = default)
    {
        var response = await _playerChallengeRepository.GetByChallenge(command.Id, command.Page, command.PageSize);

        return new GetPlayerByChallengeQueryResponse
        {
            Page = command.Page,
            TotalPages = response.totalPages,
            Players = response.playerChallenges
        };
    }
}