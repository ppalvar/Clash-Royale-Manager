using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ListClanQueryHandler : CommandHandler<ListClanQuery, ListClanQueryResponse>
{
    private readonly IClanRepository _repository;
    private readonly ListClanQueryMapper _mapper;

    public ListClanQueryHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new ListClanQueryMapper();
    }
    
    public async override Task<ListClanQueryResponse> ExecuteAsync(ListClanQuery command, CancellationToken ct = default)
    {
        return _mapper.ToResponse(await _repository.GetAll());
    }
}