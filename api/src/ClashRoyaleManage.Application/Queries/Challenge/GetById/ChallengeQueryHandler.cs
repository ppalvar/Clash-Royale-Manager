using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ChallengeQueryHandler : ICommandHandler<ChallengeQuery, ChallengeQueryResponse>
{
    private readonly IChallengeRepository _repository;
    private readonly ChallengeQueryMapper _mapper;

    public ChallengeQueryHandler(IChallengeRepository repository)
    {
        _repository = repository;
        _mapper = new ChallengeQueryMapper();
    }
    
    public async Task<ChallengeQueryResponse> ExecuteAsync(ChallengeQuery command, CancellationToken ct = default)
    {
        var data = await _repository.Get(command.Id);
        var response = _mapper.ToResponse(data);

        return response;
    }
}