using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public class StructureCardQueryHandler : CommandHandler<StructureCardQuery, StructureCardQueryResponse>
{
    private readonly IStructureCardRepository _repository;
    private readonly StructureCardQueryMapper _mapper;

    public StructureCardQueryHandler(IStructureCardRepository repository)
    {
        _repository = repository;
        _mapper = new StructureCardQueryMapper();
    }

    public override async Task<StructureCardQueryResponse> ExecuteAsync(StructureCardQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.Get(command.Id);

        return new StructureCardQueryResponse
        {
            LifePoints = entitie.Value.StructureCard.LifePoints,
            Name = entitie.Value.Name,
            Description = entitie.Value.Description
        };
    }
}