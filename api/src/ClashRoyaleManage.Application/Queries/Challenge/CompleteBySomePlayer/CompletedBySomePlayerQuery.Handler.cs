using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class CompletedBySomePlayerQueryHandler(IChallengeRepository _challengeRepository) : CommandHandler<CompletedBySomePlayerQuery, ListChallengeQueryResponse>
{
    public override async Task<ListChallengeQueryResponse> ExecuteAsync(CompletedBySomePlayerQuery command, CancellationToken ct = default)
    {
        var resp = await _challengeRepository.CompletedBySomePlayer(command.Page, command.PageSize);

        return new ListChallengeQueryResponse { Challenges = resp.Challenges, Page = resp.Page, TotalPages = resp.TotalPages };
    }
}