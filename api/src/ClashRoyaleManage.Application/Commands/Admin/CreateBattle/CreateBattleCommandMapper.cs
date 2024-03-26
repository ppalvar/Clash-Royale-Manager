using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateBattle;

public class CreateBattleCommandMapper : AbstractMapper<Battle, CreateBattleCommand, CreateBattleCommandResponse>
{
    public override Battle ToEntity(CreateBattleCommand command)
    {
        return new Battle{
            Player1Id = command.Player1Id,
            Player2Id = command.Player2Id,
            Winner = command.Winner,
            NumberOfTrophies = command.NumberOfTrophies,
            Date = command.Date,
            Duration = command.Duration,
        };
    }
    public override CreateBattleCommandResponse ToResponse(Battle entity)
    {
        return new CreateBattleCommandResponse
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
