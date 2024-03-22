using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public class PlayerQueryHandler : CommandHandler<PlayerQuery, PlayerQueryResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly PlayerQueryMapper _mapper;

    public PlayerQueryHandler(IPlayerRepository repository)
    {
        _repository = repository;
        _mapper = new PlayerQueryMapper();
    }

    public override async Task<PlayerQueryResponse> ExecuteAsync(PlayerQuery command, CancellationToken ct = default)
    {
        var data = await _repository.Get(command.Id);
        var response = _mapper.ToResponse(data);

        return response;
    }
}