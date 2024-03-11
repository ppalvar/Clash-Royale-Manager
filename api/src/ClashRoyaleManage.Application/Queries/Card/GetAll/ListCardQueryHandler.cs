using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class ListCardQueryHandler : ICommandHandler<ListCardQuery, ListCardQueryResponse>
{
    private readonly ICardRepository _repository;
    private readonly ListCardQueryMapper _mapper;

    public ListCardQueryHandler(ICardRepository repository)
    {
        _repository = repository;
        _mapper = new ListCardQueryMapper();
    }
    
    public async Task<ListCardQueryResponse> ExecuteAsync(ListCardQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetPagination(command.Page, command.Size);
        
        return new ListCardQueryResponse {
            Cards = data.Cards,
            Page = data.Page,
            TotalPages = data.TotalPages
        };
    }
}