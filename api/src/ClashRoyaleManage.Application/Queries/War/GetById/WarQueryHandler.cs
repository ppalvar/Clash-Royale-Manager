using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Wars;

public class WarQueryHandler : ICommandHandler<WarQuery, WarQueryResponse>
{
    private readonly IWarRepository _repository;
    private readonly WarQueryMapper _mapper;

    public WarQueryHandler(IWarRepository repository)
    {
        _repository = repository;
        _mapper = new WarQueryMapper();
    }
    
    public async Task<WarQueryResponse> ExecuteAsync(WarQuery command, CancellationToken ct = default)
    {
        var data = await _repository.Get(command.Id);
        var response = _mapper.ToResponse(data);

        return response;
    }
}