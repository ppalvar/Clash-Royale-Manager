using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;

public class DeletePlayerCommandMapper : AbstractMapper<Player, DeletePlayerCommand, DeletePlayerCommandResponse>
{
    public override DeletePlayerCommandResponse ToResponse(Player entity)
    {
        return new DeletePlayerCommandResponse
        {
            Nickname = entity.Nickname,
            Level = entity.Level,
            NumberOfTrophies = entity.NumberOfTrophies,
            NumberOfWins = entity.NumberOfWins,
            MaximunTrophiesAchieved = entity.MaximunTrophiesAchieved,
            NumberOfCardsFound = entity.NumberOfCardsFound
        };
    }
}
