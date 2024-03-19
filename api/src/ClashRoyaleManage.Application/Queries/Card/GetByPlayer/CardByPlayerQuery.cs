using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardByPlayerQuery : ICommand<CardByPlayerQueryResponse>
{
    public Guid Id { get; set; }
}