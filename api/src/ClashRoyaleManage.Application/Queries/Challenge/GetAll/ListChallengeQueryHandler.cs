using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ListChallengeQueryHandler : ICommandHandler<ListChallengeQuery, ListChallengeQueryResponse>
{
    private readonly IChallengeRepository _repository;
    private readonly ListChallengeQueryMapper _mapper;

    public ListChallengeQueryHandler(IChallengeRepository repository)
    {
        _repository = repository;
        _mapper = new ListChallengeQueryMapper();
    }
    
    public async Task<ListChallengeQueryResponse> ExecuteAsync(ListChallengeQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetPagination(command.Page, command.Size);
        
        return new ListChallengeQueryResponse {
            Challenges = data.Challenges,
            Page = data.Page,
            TotalPages = data.TotalPages
        };
    }
}