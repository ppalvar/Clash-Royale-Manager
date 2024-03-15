using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreatePlayer;

public class CreatePlayerCommandHandler : CommandHandler<CreatePlayerCommand, CreatePlayerCommandResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly CreatePlayerCommandMapper _mapper;

    public CreatePlayerCommandHandler(IPlayerRepository repository)
    {
        _repository = repository;
        _mapper = new CreatePlayerCommandMapper();
    }
    
    public override async Task<CreatePlayerCommandResponse> ExecuteAsync(CreatePlayerCommand command, CancellationToken ct = default)
    {
        Player player = _mapper.ToEntity(command);
        await _repository.Create(player);
        CreatePlayerCommandResponse dev = _mapper.ToResponse(player);
        return dev;
    }
}