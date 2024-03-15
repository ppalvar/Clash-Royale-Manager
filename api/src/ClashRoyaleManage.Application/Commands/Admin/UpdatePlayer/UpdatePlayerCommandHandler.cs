using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;

public class UpdatePlayerCommandHandler : CommandHandler<UpdatePlayerCommand, UpdatePlayerCommandResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly UpdatePlayerCommandMapper _mapper;

    public UpdatePlayerCommandHandler(IPlayerRepository repository)
    {
        _repository = repository;
        _mapper = new UpdatePlayerCommandMapper();
    }
    
    public override async Task<UpdatePlayerCommandResponse> ExecuteAsync(UpdatePlayerCommand command, CancellationToken ct = default)
    {
        Player? player = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(player, command))
        {
            throw new EntityAlreadyExistException("The current player can't be modified!");
        }
        
        player.Nickname = command.Nickname;
        player.Level = command.Level;
        player.NumberOfTrophies = command.NumberOfTrophies;
        player.NumberOfWins = command.NumberOfWins;
        player.MaximunTrophiesAchieved = command.MaximunTrophiesAchieved;
        player.NumberOfCardsFound = command.NumberOfCardsFound;

        await _repository.Update(player);
        UpdatePlayerCommandResponse dev = _mapper.ToResponse(player);
        return dev;
    }

    private bool NotChanges(Player player, UpdatePlayerCommand command) => player.Nickname == command.Nickname && player.Level == command.Level
            && player.NumberOfTrophies == command.NumberOfTrophies && player.NumberOfWins == command.NumberOfWins
            && player.MaximunTrophiesAchieved == command.MaximunTrophiesAchieved && player.NumberOfCardsFound == command.NumberOfCardsFound;
}
