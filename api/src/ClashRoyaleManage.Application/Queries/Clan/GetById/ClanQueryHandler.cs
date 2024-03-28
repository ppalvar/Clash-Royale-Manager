using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ClanQueryHandler : CommandHandler<ClanQuery, ClanQueryResponse>
{
    private readonly IClanRepository _repository;
    private readonly ClanQueryMapper _mapper;

    public ClanQueryHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new ClanQueryMapper();
    }

    public override async Task<ClanQueryResponse> ExecuteAsync(ClanQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.Get(command.Id);

        return new ClanQueryResponse
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