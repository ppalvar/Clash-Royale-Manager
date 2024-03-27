using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ClanRegionQueryHandler : CommandHandler<ClanRegionQuery, ClanRegionQueryResponse>
{
    private readonly IClanRepository _repository;
    private readonly ClanRegionQueryMapper _mapper;

    public ClanRegionQueryHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new ClanRegionQueryMapper();
    }

    public override async Task<ClanRegionQueryResponse> ExecuteAsync(ClanRegionQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.GetBestRegion(command.Region);
        return new ClanRegionQueryResponse
        {
            IdType = entitie.Value.Clan!.IdType,
            Name = entitie.Value.Clan.Name,
            Description = entitie.Value.Clan.Description,
            Type = entitie.Value.Type,
            NumberOfTrophiesObtainedInWars = entitie.Value.Clan.NumberOfTrophiesObtainedInWars,
            Region = entitie.Value.Clan.Region,
            NumberOfMembers = entitie.Value.Clan.NumberOfMembers,
            TrophiesNeededToEnter = entitie.Value.Clan.TrophiesNeededToEnter
        };
    }
}