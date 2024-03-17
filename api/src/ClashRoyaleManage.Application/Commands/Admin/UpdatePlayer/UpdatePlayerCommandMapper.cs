using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;

public class UpdatePlayerCommandMapper : AbstractMapper<Player, UpdatePlayerCommand, UpdatePlayerCommandResponse>
{
    public override Player ToEntity(UpdatePlayerCommand command)
    {
        return new Player{
            Id = command.Id,
            Nickname =command.Nickname,
            Level = command.Level,
            NumberOfTrophies = command.NumberOfTrophies,
            NumberOfWins = command.NumberOfWins,
            MaximunTrophiesAchieved = command.MaximunTrophiesAchieved,
            NumberOfCardsFound = command.NumberOfCardsFound
        };
    }
    public override UpdatePlayerCommandResponse ToResponse(Player entity)
    {
        return new UpdatePlayerCommandResponse
        {
            Id = entity.Id,
            Nickname = entity.Nickname,
            Level = entity.Level,
            NumberOfTrophies = entity.NumberOfTrophies,
            NumberOfWins = entity.NumberOfWins,
            MaximunTrophiesAchieved = entity.MaximunTrophiesAchieved,
            NumberOfCardsFound = entity.NumberOfCardsFound   
        };
    }
}
