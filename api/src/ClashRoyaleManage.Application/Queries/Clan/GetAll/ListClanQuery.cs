using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public record ListClanQuery() : ICommand<ListClanQueryResponse>;