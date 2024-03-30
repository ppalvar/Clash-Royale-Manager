using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteBattle;

public class DeleteBattleCommandHandler : CommandHandler<DeleteBattleCommand, DeleteBattleCommandResponse>
{
    private readonly IBattleRepository _repository;
    private readonly DeleteBattleCommandMapper _mapper;

    public DeleteBattleCommandHandler(IBattleRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteBattleCommandMapper();
    }
    
    public override async Task<DeleteBattleCommandResponse> ExecuteAsync(DeleteBattleCommand command, CancellationToken ct = default)
    {
        BattlePlayerInfo? battlePlayerInfo = await _repository.Get(command.Id, command.Date)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> and Id <{command.Id}> not exists");

        await _repository.Remove(battlePlayerInfo.Battle!);
        
        return _mapper.ToResponse(battlePlayerInfo.Battle!);
    }
}
