using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;

public class CreateStructureCardCommandHandler : CommandHandler<CreateStructureCardCommand, CreateStructureCardCommandResponse>
{
    private readonly IStructureCardRepository _repository;
    private readonly CreateStructureCardCommandMapper _mapper;

    public CreateStructureCardCommandHandler(IStructureCardRepository repository)
    {
        _repository = repository;
        _mapper = new CreateStructureCardCommandMapper();
    }
    
    public override async Task<CreateStructureCardCommandResponse> ExecuteAsync(CreateStructureCardCommand command, CancellationToken ct = default)
    {
        StructureCard structureCard = _mapper.ToEntity(command);
        await _repository.Create(structureCard);
        CreateStructureCardCommandResponse dev = _mapper.ToResponse(structureCard);
        return dev;
    }
}