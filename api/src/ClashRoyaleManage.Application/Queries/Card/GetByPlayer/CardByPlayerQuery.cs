using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardByPlayerQuery : ICommand<CardByPlayerQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}