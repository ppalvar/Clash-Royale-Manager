using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateClan;

public class CreateClanCommand : ICommand<CreateClanCommandResponse>
{
    public Guid IdType { get; set; }
    public Guid IdLider { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public int NumberOfTrophiesObtainedInWars { get; set; }

    public int Region { get; set; }

    public int NumberOfMembers { get; set; }

    public int TrophiesNeededToEnter { get; set; }

}