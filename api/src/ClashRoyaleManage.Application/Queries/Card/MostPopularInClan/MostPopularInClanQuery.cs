using System.Windows.Input;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Cards;

public class MostPopularInClanQuery : ICommand<ListCardQueryResponse>
{
    [FromRoute]
    public Guid ClanId { get; set; }

    public int Page { get; set; }
    public int PageSize { get; set; }
}