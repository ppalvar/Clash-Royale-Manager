using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Wars;

public class ListWarQueryHandler : ICommandHandler<ListWarQuery, ListWarQueryResponse>
{
    private readonly IWarRepository _repository;
    private readonly ListWarQueryMapper _mapper;

    public ListWarQueryHandler(IWarRepository repository)
    {
        _repository = repository;
        _mapper = new ListWarQueryMapper();
    }

    public async  Task<ListWarQueryResponse> ExecuteAsync(ListWarQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetAll();


        var response = _mapper.ToResponse(data);
        
        foreach (var item in response.Wars)
        {
            Console.WriteLine(item.Id);
        }

        return response;
    }
}