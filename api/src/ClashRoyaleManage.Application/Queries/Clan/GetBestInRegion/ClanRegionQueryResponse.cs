using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Clans;

public record ClanRegionQueryResponse
{
    public Guid IdType { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }    
    public int NumberOfTrophiesObtainedInWars { get; set; }

    public RegionsEnum Region { get; set; }

    public int NumberOfMembers { get; set; }

    public int TrophiesNeededToEnter { get; set; }

}