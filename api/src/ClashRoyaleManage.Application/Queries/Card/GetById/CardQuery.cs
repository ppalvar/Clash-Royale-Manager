using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardQuery : ICommand<CardQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}