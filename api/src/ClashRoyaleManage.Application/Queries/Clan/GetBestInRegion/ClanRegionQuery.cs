using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ClanRegionQuery : ICommand<ClanRegionQueryResponse>
{
    public int Region { get; set; }
}