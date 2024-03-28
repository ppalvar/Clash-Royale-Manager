using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Users;

public class ListUserQuery : ICommand<ListUserQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}