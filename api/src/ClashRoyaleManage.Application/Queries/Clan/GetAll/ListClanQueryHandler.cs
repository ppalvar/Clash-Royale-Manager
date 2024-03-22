using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ListClanQueryHandler : CommandHandler<ListClanQuery, ListClanQueryResponse>
{
    private readonly IClanRepository _repository;
    private readonly ListClanQueryMapper _mapper;

    public ListClanQueryHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new ListClanQueryMapper();
    }

    public override async Task<ListClanQueryResponse> ExecuteAsync(ListClanQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetAll();


        var response = _mapper.ToResponse(data);

        foreach (var item in response.Clans)
        {
            Console.WriteLine(item.Id);
        }

        return response;
    }
}