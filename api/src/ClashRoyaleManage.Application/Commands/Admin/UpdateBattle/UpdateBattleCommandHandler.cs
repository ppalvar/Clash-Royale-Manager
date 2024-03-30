using System.Data;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateBattle;

public class UpdateBattleCommandHandler : CommandHandler<UpdateBattleCommand, UpdateBattleCommandResponse>
{
    private readonly IBattleRepository _repository;
    private readonly UpdateBattleCommandMapper _mapper;

    public UpdateBattleCommandHandler(IBattleRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateBattleCommandMapper();
    }
    
    public override async Task<UpdateBattleCommandResponse> ExecuteAsync(UpdateBattleCommand command, CancellationToken ct = default)
    {
        BattlePlayerInfo battlePlayerInfo = await _repository.Get(command.Player1Id, command.Date)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> and Player1 <{command.Player1Id}> not exists");
        
        if (NotChanges(battlePlayerInfo, command))
        {
            throw new EntityAlreadyExistException("The current battle can't be modified!");
        }

        battlePlayerInfo.Battle!.Player2Id = command.Player2Id;
        battlePlayerInfo.Battle!.Winner = command.Winner;
        battlePlayerInfo.Battle!.NumberOfTrophies = command.NumberOfTrophies;
        battlePlayerInfo.Battle!.Duration = command.Duration;

        Battle battle = _mapper.ToEntity(battlePlayerInfo);
        await _repository.Update(battle);

        return _mapper.ToResponse(battle);
    }

    private bool NotChanges(BattlePlayerInfo battle, UpdateBattleCommand command) => 
        battle.Battle!.Player2Id == command.Player2Id && battle.Battle!.Winner == command.Winner
        && battle.Battle!.NumberOfTrophies == command.NumberOfTrophies && battle.Battle.Duration == command.Duration;
}
