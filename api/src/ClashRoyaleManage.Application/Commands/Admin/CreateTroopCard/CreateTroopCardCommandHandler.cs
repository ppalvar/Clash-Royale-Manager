using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateTroopCard;

public class CreateTroopCardCommandHandler : CommandHandler<CreateTroopCardCommand, CreateTroopCardCommandResponse>
{
    private readonly ITroopCardRepository _repository;
    private readonly CreateTroopCardCommandMapper _mapper;

    public CreateTroopCardCommandHandler(ITroopCardRepository repository)
    {
        _repository = repository;
        _mapper = new CreateTroopCardCommandMapper();
    }
    
    public override async Task<CreateTroopCardCommandResponse> ExecuteAsync(CreateTroopCardCommand command, CancellationToken ct = default)
    {
        TroopCard troopCard = _mapper.ToEntity(command);
        await _repository.Create(troopCard);
        CreateTroopCardCommandResponse dev = _mapper.ToResponse(troopCard);
        return dev;
    }
}