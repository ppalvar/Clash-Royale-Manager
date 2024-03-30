using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreatePlayer;

public class CreatePlayerCommandMapper : AbstractMapper<Player, CreatePlayerCommand, CreatePlayerCommandResponse>
{
    public override Player ToEntity(CreatePlayerCommand command)
    {
        return new Player{
            Code = command.Code,
            Nickname =command.Nickname,
            Level = command.Level,
            NumberOfTrophies = command.NumberOfTrophies,
            NumberOfWins = command.NumberOfWins,
            MaximunTrophiesAchieved = command.MaximunTrophiesAchieved,
            NumberOfCardsFound = command.NumberOfCardsFound
        };
    }
    public override CreatePlayerCommandResponse ToResponse(Player entity)
    {
        return new CreatePlayerCommandResponse
        {
            Code = entity.Code,
            Nickname = entity.Nickname,
            Level = entity.Level,
            NumberOfTrophies = entity.NumberOfTrophies,
            NumberOfWins = entity.NumberOfWins,
            MaximunTrophiesAchieved = entity.MaximunTrophiesAchieved,
            NumberOfCardsFound = entity.NumberOfCardsFound
        };
    }
}
