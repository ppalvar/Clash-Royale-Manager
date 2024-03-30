using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteBattle;

public class DeleteBattleCommandMapper : AbstractMapper<Battle, DeleteBattleCommand, DeleteBattleCommandResponse>
{
    public override DeleteBattleCommandResponse ToResponse(Battle entity)
    {
        return new DeleteBattleCommandResponse
        {
            Player1Id = entity.Player1Id,
            Player2Id = entity.Player2Id,
            Winner = entity.Winner,
            NumberOfTrophies = entity.NumberOfTrophies,
            Date = entity.Date,
            Duration = entity.Duration,
        };
    }
}
