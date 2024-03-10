using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardQuery : ICommand<CardQueryResponse>
{
    public Guid Id { get; set; }
}