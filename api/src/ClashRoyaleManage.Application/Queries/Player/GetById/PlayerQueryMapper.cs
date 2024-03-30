using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Players;

public class PlayerQueryMapper : AbstractMapper<Player, PlayerQuery, PlayerQueryResponse>
{
    public override PlayerQueryResponse ToResponse(Player entitie)
    {
        return new PlayerQueryResponse
        {
            Code = entitie.Code,
            Nickname = entitie.Nickname,
            Level = entitie.Level,
            NumberOfTrophies = entitie.NumberOfTrophies,
            NumberOfWins = entitie.NumberOfWins,
            MaximunTrophiesAchieved = entitie.MaximunTrophiesAchieved,
            NumberOfCardsFound = entitie.NumberOfCardsFound
        };
    }
}