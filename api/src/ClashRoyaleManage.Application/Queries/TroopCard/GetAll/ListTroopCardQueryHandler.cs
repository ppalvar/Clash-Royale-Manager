using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public class ListTroopCardQueryHandler : CommandHandler<ListTroopCardQuery, ListTroopCardQueryResponse>
{
    private readonly ITroopCardRepository _repository;
    private readonly ListTroopCardQueryMapper _mapper;

    public ListTroopCardQueryHandler(ITroopCardRepository repository)
    {
        _repository = repository;
        _mapper = new ListTroopCardQueryMapper();
    }

    public override async Task<ListTroopCardQueryResponse> ExecuteAsync(ListTroopCardQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetPagination(command.Page, command.Size);

        return new ListTroopCardQueryResponse
        {
            TroopCards = data.TroopCards,
            Page = data.Page,
            TotalPages = data.TotalPages
        };
    }
}