using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public class ListStructureCardQueryHandler : CommandHandler<ListStructureCardQuery, ListStructureCardQueryResponse>
{
    private readonly IStructureCardRepository _repository;
    private readonly ListStructureCardQueryMapper _mapper;

    public ListStructureCardQueryHandler(IStructureCardRepository repository)
    {
        _repository = repository;
        _mapper = new ListStructureCardQueryMapper();
    }

    public override async Task<ListStructureCardQueryResponse> ExecuteAsync(ListStructureCardQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetAll();


         return new ListStructureCardQueryResponse
        {
            StructureCards = data
        };
    }
}