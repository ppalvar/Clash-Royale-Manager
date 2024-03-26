using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public class ListPlayerQueryHandler : CommandHandler<ListPlayerQuery, ListPlayerQueryResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly ListPlayerQueryMapper _mapper;

    public ListPlayerQueryHandler(IPlayerRepository repository)
    {
        _repository = repository;
        _mapper = new ListPlayerQueryMapper();
    }

    public override async Task<ListPlayerQueryResponse> ExecuteAsync(ListPlayerQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetPagination(command.Page, command.Size);

        return new ListPlayerQueryResponse
        {
            Players = data.Players,
            Page = data.Page,
            TotalPages = data.TotalPages
        };
    }
}