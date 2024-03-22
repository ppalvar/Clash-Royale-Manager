using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardQueryHandler : CommandHandler<CardQuery, CardQueryResponse>
{
    private readonly ICardRepository _repository;
    private readonly CardQueryMapper _mapper;

    public CardQueryHandler(ICardRepository repository)
    {
        _repository = repository;
        _mapper = new CardQueryMapper();
    }

    public override async Task<CardQueryResponse> ExecuteAsync(CardQuery command, CancellationToken ct = default)
    {
        var data = await _repository.Get(command.Id);
        var response = _mapper.ToResponse(data);

        return response;
    }
}