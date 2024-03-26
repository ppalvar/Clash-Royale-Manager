using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardByPlayerQueryHandler : CommandHandler<CardByPlayerQuery, CardByPlayerQueryResponse>
{
    private readonly ICardRepository _repository;
    private readonly CardByPlayerQueryMapper _mapper;

    public CardByPlayerQueryHandler(ICardRepository repository)
    {
        _repository = repository;
        _mapper = new CardByPlayerQueryMapper();
    }

    public override async Task<CardByPlayerQueryResponse> ExecuteAsync(CardByPlayerQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetByPlayer(command.Id);
        var response = _mapper.ToResponse(data);

        return response;
    }
}