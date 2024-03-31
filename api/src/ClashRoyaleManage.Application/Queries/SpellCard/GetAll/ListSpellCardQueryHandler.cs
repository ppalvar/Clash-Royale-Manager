using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public class ListSpellCardQueryHandler : CommandHandler<ListSpellCardQuery, ListSpellCardQueryResponse>
{
    private readonly ISpellCardRepository _repository;
    private readonly ListSpellCardQueryMapper _mapper;

    public ListSpellCardQueryHandler(ISpellCardRepository repository)
    {
        _repository = repository;
        _mapper = new ListSpellCardQueryMapper();
    }

    public override async Task<ListSpellCardQueryResponse> ExecuteAsync(ListSpellCardQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetAll();


         return new ListSpellCardQueryResponse
        {
            SpellCards = data
        };
    }
}