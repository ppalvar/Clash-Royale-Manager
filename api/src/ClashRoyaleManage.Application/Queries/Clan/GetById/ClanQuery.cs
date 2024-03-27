using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ClanQuery : ICommand<ClanQueryResponse>
{
    public Guid Id { get; set; }
}