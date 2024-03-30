using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateBattle;

public class UpdateBattleCommandMapper : AbstractMapper<Battle, BattlePlayerInfo, UpdateBattleCommandResponse>
{
    public override Battle ToEntity(BattlePlayerInfo battle)
    {
        return new Battle{
            Player1Id = battle.Battle!.Player1Id,
            Player2Id = battle.Battle!.Player2Id,
            Winner = battle.Battle!.Winner,
            NumberOfTrophies = battle.Battle!.NumberOfTrophies,
            Date = battle.Battle!.Date,
            Duration = battle.Battle!.Duration
        };
    }
    public override UpdateBattleCommandResponse ToResponse(Battle entity)
    {
        return new UpdateBattleCommandResponse
        {
            Player1Id = entity.Player1Id,
            Player2Id = entity.Player2Id,
            Winner = entity.Winner,
            NumberOfTrophies = entity.NumberOfTrophies,
            Date = entity.Date,
            Duration = entity.Duration
        };
    }
}
