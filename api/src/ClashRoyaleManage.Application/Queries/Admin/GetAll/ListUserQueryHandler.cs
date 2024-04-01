using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Users;

public class ListUserQueryHandler : CommandHandler<ListUserQuery, ListUserQueryResponse>
{
    private readonly IUserRepository _repository;
    private readonly ListUserQueryMapper _mapper;

    public ListUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
        _mapper = new ListUserQueryMapper();
    }

    public override async Task<ListUserQueryResponse> ExecuteAsync(ListUserQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetPagination(command.Page, command.Size);

        return new ListUserQueryResponse
        {
            Users = data.Users,
            Page = data.Page,
            TotalPages = data.TotalPages
        };
    }
}