using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Cards;

public record MostDonatedCardInRegionQuery : ICommand<Card?>
{
    [FromRoute]
    public RegionsEnum Region { get; set; }
}