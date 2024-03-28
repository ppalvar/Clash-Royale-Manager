using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateClan;

public class UpdateClanCommandHandler : CommandHandler<UpdateClanCommand, UpdateClanCommandResponse>
{
    private readonly IClanRepository _repository;
    private readonly UpdateClanCommandMapper _mapper;

    public UpdateClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateClanCommandMapper();
    }
    
    public override async Task<UpdateClanCommandResponse> ExecuteAsync(UpdateClanCommand command, CancellationToken ct = default)
    {
        Clan? clan = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(clan, command))
        {
            throw new EntityAlreadyExistException("The current challenge can't be modified!");
        }
        
        clan.Name = command.Name;
        clan.Description = command.Description;
        clan.IdType = command.IdType;
        clan.NumberOfTrophiesObtainedInWars = command.NumberOfTrophiesObtainedInWars;
        clan.Region = command.Region;
        clan.NumberOfMembers = command.NumberOfMembers;
        clan.TrophiesNeededToEnter = command.TrophiesNeededToEnter;
        
        await _repository.Update(clan);
        UpdateClanCommandResponse dev = _mapper.ToResponse(clan);
        return dev;
    }

    private bool NotChanges(Clan clan, UpdateClanCommand command) => clan.Name == command.Name && clan.Description == command.Description
            && clan.IdType == command.IdType && clan.NumberOfTrophiesObtainedInWars == command.NumberOfTrophiesObtainedInWars
            && clan.Region == command.Region && clan.NumberOfMembers == command.NumberOfMembers && clan.TrophiesNeededToEnter ==command.TrophiesNeededToEnter;
}
